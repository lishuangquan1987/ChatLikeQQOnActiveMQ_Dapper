using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatLikeQQOnActiveMQ.Driver;
using ChatLikeQQOnActiveMQ.Model;
using Newtonsoft.Json;
using ChatLikeQQOnActiveMQ.BLL;

namespace ChatLikeQQOnActiveMQ.Server
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        DataBaseBLL dataBaseBLL = new DataBaseBLL();
        UserBLL userBLL = new UserBLL();
        PointToPointChatBLL pointToPointChatBLL = new PointToPointChatBLL();
        string ipStr = System.Configuration.ConfigurationManager.AppSettings["IpStr"];
        ConsumerQuene consumerQuene;
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataBaseBLL.InitDataBase();
            consumerQuene = new ConsumerQuene(ipStr,"ServerQuene");
            consumerQuene.MessageReceived += ConsumerQuene_MessageReceived;
            this.DataContext = mainWindowViewModel;
            
        }

        private void ConsumerQuene_MessageReceived(string obj)
        {
            MsgModel msgModel = JsonConvert.DeserializeObject<MsgModel>(obj);
            msgModel.Time = DateTime.Now;
            switch (msgModel.MsgType)
            {
                case MsgType.PointToPoint://transfer to the to quene
                    ChatLikeQQOnActiveMQ.Common.DriverHelper.SendMsgToQuene(msgModel.To,JsonConvert.SerializeObject(msgModel));
                    var pointToPoint = JsonConvert.DeserializeObject<PointToPoint>(msgModel.Msg);
                    pointToPointChatBLL.SaveOneRecord(pointToPoint);
                    this.Dispatcher.Invoke(new Action(() => mainWindowViewModel.PointToPointList.Add(new PointToPointModel() { Content = pointToPoint.Content, DateTime = pointToPoint.Time, From = pointToPoint.From, To = pointToPoint.To })));
                    break;
                case MsgType.PubSub://transfer to the group quene
                    ChatLikeQQOnActiveMQ.Common.DriverHelper.SendMsgToTopic(msgModel.To,JsonConvert.SerializeObject(msgModel));
                    break;
                case MsgType.Login://transfer to from
                    User user = JsonConvert.DeserializeObject<User>(msgModel.Msg);
                    string msg = "";
                    var result= userBLL.Login(user.UserName, user.Password, out msg);
                    //返回消息给发送者
                    ChatLikeQQOnActiveMQ.Common.DriverHelper.SendMsgToQuene(msgModel.From, JsonConvert.SerializeObject(new { Result = result,Msg=msg }));                    
                    break;
                case MsgType.Register://handle the register request
                    User regUser = JsonConvert.DeserializeObject<User>(msgModel.Msg);
                    string msgRegister = "";
                    var resultRegister = userBLL.Register(regUser,out msgRegister);
                    ChatLikeQQOnActiveMQ.Common.DriverHelper.SendMsgToQuene(msgModel.From, JsonConvert.SerializeObject(new { Result = resultRegister, Msg = msgRegister }));
                    break;
                case MsgType.AddFriend:
                    break;
                case MsgType.SearchFriend:
                    break;
                case MsgType.LoadUserDetail:
                    string userName = msgModel.Msg;
                    User u = userBLL.GetUser(userName);
                    ChatLikeQQOnActiveMQ.Common.DriverHelper.SendMsgToQuene(msgModel.From,JsonConvert.SerializeObject(u));
                    break;
                default:
                    break;
            }
        }
        
    }
}
