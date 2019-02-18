using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using ChatLikeQQOnActiveMQ.Driver;
using System.Configuration;
using ChatLikeQQOnActiveMQ.Common;
using ChatLikeQQOnActiveMQ.Model;
using Newtonsoft.Json;
using System.Windows.Threading;

namespace ChatLikeQQOnActiveMQ.Client
{
    /// <summary>
    /// LoginForm.xaml 的交互逻辑
    /// </summary>
    public partial class LoginForm : Window
    {
        Random _random = new Random();
        ConsumerQuene consumerQuene;
        EnLoginStatus status = EnLoginStatus.Ready;
        string guid;
        private bool isEnterLogin = false;
        public User CurrentUser;

        //布局宽490 高210 显示宽430 高180
        //阵距4行8列 点之间的距离 X轴Y轴都是70
        /// <summary>
        /// 点信息阵距
        /// </summary>
        private PointInfo[,] _points = new PointInfo[8, 4];

        /// <summary>
        /// 计时器
        /// </summary>
        private DispatcherTimer _timer;
        
        int currentTxtPosition = 0;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (status== EnLoginStatus.Ready)
            {
                MsgModel model = new MsgModel();
                model.From = guid;
                model.To = "ServerQuene";
                model.MsgType = MsgType.Login;
                User user = new User() { UserName = this.cbUserName.Text, Password = this.tbPassword.Password };
                model.Msg = JsonConvert.SerializeObject(user);
                DriverHelper.SendMsgToQuene("ServerQuene", JsonConvert.SerializeObject(model));

                status = EnLoginStatus.Login;
                this.btnLogin.Content = "取消";
                //开始动画
                DoubleAnimation ani1 = new DoubleAnimation();
                ani1.From = 1;
                ani1.To = 0;
                ani1.Duration = TimeSpan.FromMilliseconds(100);
                spLogin.BeginAnimation(StackPanel.OpacityProperty, ani1);

                DoubleAnimation ani2 = new DoubleAnimation();
                ani2.From = 0;
                ani2.To = 1;
                ani2.Duration = TimeSpan.FromMilliseconds(100);
                spLoading.BeginAnimation(StackPanel.OpacityProperty, ani2);
            }
            else if(status== EnLoginStatus.Login)
            {
                status = EnLoginStatus.Ready;
                this.btnLogin.Content = "登录";
                //开始动画
                DoubleAnimation ani1 = new DoubleAnimation();
                ani1.From = 0;
                ani1.To = 1;
                ani1.Duration = TimeSpan.FromMilliseconds(500);
                spLogin.BeginAnimation(StackPanel.OpacityProperty, ani1);
                

                DoubleAnimation ani2 = new DoubleAnimation();
                ani2.From = 1;
                ani2.To = 0;
                ani2.Duration = TimeSpan.FromMilliseconds(500);
                spLoading.BeginAnimation(StackPanel.OpacityProperty, ani2);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            #region 水晶动画
            Init();
            //注册帧动画
            _timer = new System.Windows.Threading.DispatcherTimer();
            _timer.Tick += new EventHandler(PolyAnimation);
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 24);//一秒钟刷新24次
            _timer.Start();
            #endregion

            #region 消费者，用于接收登录或者注册的返回消息，使用一个guid
            guid = Guid.NewGuid().ToString();
            guid = "Login_" + guid;
            string ip = ConfigurationManager.AppSettings["IpStr"];
            consumerQuene = new ConsumerQuene(ip,guid);
            consumerQuene.MessageReceived += ConsumerQuene_MessageReceived;
            #endregion

 
        }

       
       
        private void ConsumerQuene_MessageReceived(string obj)
        {
            if (status == EnLoginStatus.Login)
            {
                
                var result = JsonConvert.DeserializeObject<LoginResult>(obj);
                string userName = "";
                if (result.Result)
                {
                    status = EnLoginStatus.LoadUser;
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        this.btnLogin.IsEnabled = false;
                        this.btnLogin.Content = "登录成功，正在获取用户信息...";
                        userName = this.cbUserName.Text;
                    }));
                    MsgModel model = new MsgModel();
                    model.From = guid;
                    model.To = "ServerQuene";
                    model.MsgType = MsgType.LoadUserDetail;
                    model.Msg = userName;
                    DriverHelper.SendMsgToQuene("ServerQuene", JsonConvert.SerializeObject(model));
                    
                }
                else
                {
                    MessageBox.Show(result.Msg);
                }
            }
            else if (status == EnLoginStatus.LoadUser)
            {
                CurrentUser = JsonConvert.DeserializeObject<User>(obj);
                if (CurrentUser == null)
                {
                    MessageBox.Show("加载用户信息失败！");
                    this.Dispatcher.Invoke((Action)(() => this.DialogResult = false));
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        DoubleAnimation animation = new DoubleAnimation();
                        animation.From = this.Width;
                        animation.To = 0;
                        animation.Duration = TimeSpan.FromMilliseconds(500);
                        animation.Completed += (s, e) => this.Dispatcher.Invoke((Action)(() => this.DialogResult = true));
                        this.BeginAnimation(Window.WidthProperty, animation);
                    }));
                }
            }

        }

        #region 水晶动画相关
        /// <summary>
        /// 初始化阵距
        /// </summary>
        private void Init()
        {
            //生成阵距的点
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    double x = _random.Next(-11, 11);
                    double y = _random.Next(-6, 6);
                    _points[i, j] = new PointInfo()
                    {
                        X = i * 70,
                        Y = j * 70,
                        SpeedX = x / 24,
                        SpeedY = y / 24,
                        DistanceX = _random.Next(35, 106),
                        DistanceY = _random.Next(20, 40),
                        MovedX = 0,
                        MovedY = 0,
                        PolygonInfoList = new List<PolygonInfo>()
                    };
                }
            }

            byte r = (byte)_random.Next(0, 11);
            byte g = (byte)_random.Next(100, 201);
            int intb = g + _random.Next(50, 101);
            if (intb > 255)
                intb = 255;
            byte b = (byte)intb;

            //上一行取2个点 下一行取1个点
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Polygon poly = new Polygon();
                    poly.Points.Add(new Point(_points[i, j].X, _points[i, j].Y));
                    _points[i, j].PolygonInfoList.Add(new PolygonInfo() { PolygonRef = poly, PointIndex = 0 });
                    poly.Points.Add(new Point(_points[i + 1, j].X, _points[i + 1, j].Y));
                    _points[i + 1, j].PolygonInfoList.Add(new PolygonInfo() { PolygonRef = poly, PointIndex = 1 });
                    poly.Points.Add(new Point(_points[i + 1, j + 1].X, _points[i + 1, j + 1].Y));
                    _points[i + 1, j + 1].PolygonInfoList.Add(new PolygonInfo() { PolygonRef = poly, PointIndex = 2 });
                    poly.Fill = new SolidColorBrush(Color.FromRgb(r, g, (byte)b));
                    SetColorAnimation(poly);
                    layout.Children.Add(poly);
                }
            }

            //上一行取1个点 下一行取2个点
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Polygon poly = new Polygon();
                    poly.Points.Add(new Point(_points[i, j].X, _points[i, j].Y));
                    _points[i, j].PolygonInfoList.Add(new PolygonInfo() { PolygonRef = poly, PointIndex = 0 });
                    poly.Points.Add(new Point(_points[i, j + 1].X, _points[i, j + 1].Y));
                    _points[i, j + 1].PolygonInfoList.Add(new PolygonInfo() { PolygonRef = poly, PointIndex = 1 });
                    poly.Points.Add(new Point(_points[i + 1, j + 1].X, _points[i + 1, j + 1].Y));
                    _points[i + 1, j + 1].PolygonInfoList.Add(new PolygonInfo() { PolygonRef = poly, PointIndex = 2 });
                    poly.Fill = new SolidColorBrush(Color.FromRgb(r, g, (byte)b));
                    SetColorAnimation(poly);
                    layout.Children.Add(poly);
                }
            }
        }

        /// <summary>
        /// 设置颜色动画
        /// </summary>
        /// <param name="polygon">多边形</param>
        private void SetColorAnimation(UIElement polygon)
        {
            //颜色动画的时间 1-4秒随机
            Duration dur = new Duration(new TimeSpan(0, 0, _random.Next(1, 5)));
            //故事版
            Storyboard sb = new Storyboard()
            {
                Duration = dur
            };
            sb.Completed += (S, E) => //动画执行完成事件
            {
                //颜色动画完成之后 重新set一个颜色动画
                SetColorAnimation(polygon);
            };
            //颜色动画
            //颜色的RGB
            byte r = (byte)_random.Next(0, 11);
            byte g = (byte)_random.Next(100, 201);
            int intb = g + _random.Next(50, 101);
            if (intb > 255)
                intb = 255;
            byte b = (byte)intb;
            ColorAnimation ca = new ColorAnimation()
            {
                To = Color.FromRgb(r, g, b),
                Duration = dur
            };
            Storyboard.SetTarget(ca, polygon);
            Storyboard.SetTargetProperty(ca, new PropertyPath("Fill.Color"));
            sb.Children.Add(ca);
            sb.Begin(this);
        }

        /// <summary>
        /// 多边形变化动画
        /// </summary>
        void PolyAnimation(object sender, EventArgs e)
        {
            //不改变阵距最外边一层的点
            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    PointInfo pointInfo = _points[i, j];
                    pointInfo.X += pointInfo.SpeedX;
                    pointInfo.Y += pointInfo.SpeedY;
                    pointInfo.MovedX += pointInfo.SpeedX;
                    pointInfo.MovedY += pointInfo.SpeedY;
                    if (pointInfo.MovedX >= pointInfo.DistanceX || pointInfo.MovedX <= -pointInfo.DistanceX)
                    {
                        pointInfo.SpeedX = -pointInfo.SpeedX;
                        pointInfo.MovedX = 0;
                    }
                    if (pointInfo.MovedY >= pointInfo.DistanceY || pointInfo.MovedY <= -pointInfo.DistanceY)
                    {
                        pointInfo.SpeedY = -pointInfo.SpeedY;
                        pointInfo.MovedY = 0;
                    }
                    //改变多边形的点
                    foreach (PolygonInfo pInfo in _points[i, j].PolygonInfoList)
                    {
                        pInfo.PolygonRef.Points[pInfo.PointIndex] = new Point(pointInfo.X, pointInfo.Y);
                    }
                }
            }
        }
        #endregion

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(this.btnLogin, null);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    /// <summary>
    /// 阵距点信息
    /// </summary>
    public class PointInfo
    {
        /// <summary>
        /// X坐标
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y坐标
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// X轴速度 wpf距离单位/二十四分之一秒
        /// </summary>
        public double SpeedX { get; set; }

        /// <summary>
        /// Y轴速度 wpf距离单位/二十四分之一秒
        /// </summary>
        public double SpeedY { get; set; }

        /// <summary>
        /// X轴需要移动的距离
        /// </summary>
        public double DistanceX { get; set; }

        /// <summary>
        /// Y轴需要移动的距离
        /// </summary>
        public double DistanceY { get; set; }

        /// <summary>
        /// X轴已经移动的距离
        /// </summary>
        public double MovedX { get; set; }

        /// <summary>
        /// Y轴已经移动的距离
        /// </summary>
        public double MovedY { get; set; }

        /// <summary>
        /// 多边形信息列表
        /// </summary>
        public List<PolygonInfo> PolygonInfoList { get; set; }
    }

    /// <summary>
    /// 多边形信息
    /// </summary>
    public class PolygonInfo
    {
        /// <summary>
        /// 对多边形的引用
        /// </summary>
        public Polygon PolygonRef { get; set; }

        /// <summary>
        /// 需要改变的点的索引
        /// </summary>
        public int PointIndex { get; set; }
    }

    public enum EnLoginStatus
    {
        Ready,
        Login,
        LoadUser,
    }
}
