using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
namespace ChatLikeQQOnActiveMQ.Client
{
    public  class WindowResizer:Window
    {
        private bool resizeRight = false;
        private bool resizeLeft = false;
        private bool resizeUp = false;
        private bool resizeDown = false;

        private Dictionary<UIElement, short> leftElements = new Dictionary<UIElement, short>();
        private Dictionary<UIElement, short> rightElements = new Dictionary<UIElement, short>();
        private Dictionary<UIElement, short> upElements = new Dictionary<UIElement, short>();
        private Dictionary<UIElement, short> downElements = new Dictionary<UIElement, short>();
        private SolidColorBrush solidColor = new SolidColorBrush(Colors.Transparent);

        private PointAPI resizePoint = new PointAPI();
        private Size resizeSize = new Size();
        private Point resizeWindowPoint = new Point();

        private delegate void RefreshDelegate();

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Init_New();
        }
        private void Init()
        {
            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;
            //得到Window的Content保存起来
            UIElement content = this.Content as UIElement;
            //移除Window的Cotent
            this.SetValue(ContentPresenter.ContentProperty, null);
            this.ClearValue(ContentPresenter.ContentProperty);

            //将Window原来的Cotent添加进去
            Grid.SetRow(content, 1);
            Grid.SetColumn(content, 1);


            Grid grid = new Grid();
            grid.Children.Add(content);


            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(3) });
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(3) });

            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3) });



            Rectangle rectLeft = new Rectangle() { Fill =solidColor };
            Grid.SetRow(rectLeft, 1);
            Grid.SetColumn(rectLeft, 0);
            grid.Children.Add(rectLeft);

            Rectangle rectRight = new Rectangle() { Fill =solidColor };
            Grid.SetRow(rectRight, 1);
            Grid.SetColumn(rectRight, 2);
            grid.Children.Add(rectRight);

            Rectangle rectTop = new Rectangle() { Fill = solidColor };
            Grid.SetRow(rectTop, 0);
            Grid.SetColumn(rectTop, 1);
            grid.Children.Add(rectTop);

            Rectangle rectBottom = new Rectangle() { Fill = solidColor };
            Grid.SetRow(rectBottom, 2);
            Grid.SetColumn(rectBottom, 1);
            grid.Children.Add(rectBottom);

            Rectangle rectLeftBottom = new Rectangle() { Fill = solidColor };
            Grid.SetRow(rectLeftBottom, 2);
            Grid.SetColumn(rectLeftBottom, 0);
            grid.Children.Add(rectLeftBottom);

            Rectangle rectRightBottom = new Rectangle() { Fill = solidColor };
            Grid.SetRow(rectRightBottom, 2);
            Grid.SetColumn(rectRightBottom, 2);
            grid.Children.Add(rectRightBottom);
            //赋值Window的Content
            this.Content = grid;

            //绑定
            this.addResizerLeft(rectLeft);
            this.addResizerLeftDown(rectLeftBottom);
            this.addResizerRightDown(rectRightBottom);
            this.addResizerRight(rectRight);
            this.addResizerUp(rectTop);
            this.addResizerDown(rectBottom);
        }
        private void Init_New()
        {
            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;
            //得到Window的Content保存起来
            UIElement content = this.Content as UIElement;
            //移除Window的Cotent
            this.SetValue(ContentPresenter.ContentProperty, null);
            this.ClearValue(ContentPresenter.ContentProperty);

            //将Window原来的Cotent添加进去
            Grid grid = new Grid();
            grid.Children.Add(content);


            Rectangle rectLeft = new Rectangle() { Fill = solidColor,HorizontalAlignment= HorizontalAlignment.Left,Width=3};
            grid.Children.Add(rectLeft);

            Rectangle rectRight = new Rectangle() { Fill = solidColor ,HorizontalAlignment= HorizontalAlignment.Right,Width=3};
            grid.Children.Add(rectRight);

            Rectangle rectTop = new Rectangle() { Fill = solidColor,VerticalAlignment= VerticalAlignment.Top,Height=3 };
            grid.Children.Add(rectTop);

            Rectangle rectBottom = new Rectangle() { Fill = solidColor,VerticalAlignment= VerticalAlignment.Bottom,Height=3 };
            grid.Children.Add(rectBottom);

            Rectangle rectLeftBottom = new Rectangle() { Fill = solidColor,HorizontalAlignment= HorizontalAlignment.Left,VerticalAlignment= VerticalAlignment.Bottom,Height=3,Width=3};
            grid.Children.Add(rectLeftBottom);

            Rectangle rectRightBottom = new Rectangle() { Fill = solidColor,HorizontalAlignment= HorizontalAlignment.Right,VerticalAlignment= VerticalAlignment.Bottom,Height=3,Width=3 };
            grid.Children.Add(rectRightBottom);
            //赋值Window的Content
            this.Content = grid;

            //绑定
            this.addResizerLeft(rectLeft);
            this.addResizerLeftDown(rectLeftBottom);
            this.addResizerRightDown(rectRightBottom);
            this.addResizerRight(rectRight);
            this.addResizerUp(rectTop);
            this.addResizerDown(rectBottom);
        }
        public WindowResizer()
        {
            
        }

        #region add resize components  
        private void connectMouseHandlers(UIElement element)
        {
            element.MouseLeftButtonDown += new MouseButtonEventHandler(element_MouseLeftButtonDown);
            element.MouseEnter += new System.Windows.Input.MouseEventHandler(element_MouseEnter);
            element.MouseLeave += new System.Windows.Input.MouseEventHandler(setArrowCursor);
        }

        public void addResizerRight(UIElement element)
        {
            connectMouseHandlers(element);
            rightElements.Add(element, 0);
        }

        public void addResizerLeft(UIElement element)
        {
            connectMouseHandlers(element);
            leftElements.Add(element, 0);
        }

        public void addResizerUp(UIElement element)
        {
            connectMouseHandlers(element);
            upElements.Add(element, 0);
        }

        public void addResizerDown(UIElement element)
        {
            connectMouseHandlers(element);
            downElements.Add(element, 0);
        }

        public void addResizerRightDown(UIElement element)
        {
            connectMouseHandlers(element);
            rightElements.Add(element, 0);
            downElements.Add(element, 0);
        }

        public void addResizerLeftDown(UIElement element)
        {
            connectMouseHandlers(element);
            leftElements.Add(element, 0);
            downElements.Add(element, 0);
        }

        public void addResizerRightUp(UIElement element)
        {
            connectMouseHandlers(element);
            rightElements.Add(element, 0);
            upElements.Add(element, 0);
        }

        public void addResizerLeftUp(UIElement element)
        {
            connectMouseHandlers(element);
            leftElements.Add(element, 0);
            upElements.Add(element, 0);
        }
        #endregion

        #region resize handlers  
        private void element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GetCursorPos(out resizePoint);
            resizeSize = new Size(this.Width, this.Height);
            resizeWindowPoint = new Point(this.Left, this.Top);
            e.Handled = true;
            #region updateResizeDirection  
            UIElement sourceSender = (UIElement)sender;
            if (leftElements.ContainsKey(sourceSender))
            {
                resizeLeft = true;
            }
            if (rightElements.ContainsKey(sourceSender))
            {
                resizeRight = true;
            }
            if (upElements.ContainsKey(sourceSender))
            {
                resizeUp = true;
            }
            if (downElements.ContainsKey(sourceSender))
            {
                resizeDown = true;
            }
            #endregion

            Thread t = new Thread(new ThreadStart(updateSizeLoop));
            t.Name = "Mouse Position Poll Thread";
            t.Start();
        }

        private void updateSizeLoop()
        {
            try
            {
                while (resizeDown || resizeLeft || resizeRight || resizeUp)
                {
                    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new RefreshDelegate(updateSize));
                    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new RefreshDelegate(updateMouseDown));
                    Thread.Sleep(20);
                }

                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new RefreshDelegate(setArrowCursor));
            }
            catch (Exception)
            {
            }
        }

        #region updates  
        private void updateSize()
        {
            try
            {
                PointAPI p = new PointAPI();
                GetCursorPos(out p);

                if (resizeRight)
                {
                    this.Width = this.resizeSize.Width - (resizePoint.X - p.X);
                }

                if (resizeDown)
                {
                    this.Height = resizeSize.Height - (resizePoint.Y - p.Y);
                }

                if (resizeLeft)
                {
                    this.Width = resizeSize.Width + (resizePoint.X - p.X);
                    this.Left = resizeWindowPoint.X - (resizePoint.X - p.X);
                }

                if (resizeUp)
                {
                    this.Height = resizeSize.Height + (resizePoint.Y - p.Y);
                    this.Top = resizeWindowPoint.Y - (resizePoint.Y - p.Y);
                }
            }
            catch { }
        }

        private void updateMouseDown()
        {
            if (Mouse.LeftButton == MouseButtonState.Released)
            {
                resizeRight = false;
                resizeLeft = false;
                resizeUp = false;
                resizeDown = false;
            }
        }
        #endregion
        #endregion

        #region cursor updates  
        private void element_MouseEnter(object sender, MouseEventArgs e)
        {
            bool resizeRight = false;
            bool resizeLeft = false;
            bool resizeUp = false;
            bool resizeDown = false;

            UIElement sourceSender = (UIElement)sender;
            if (leftElements.ContainsKey(sourceSender))
            {
                resizeLeft = true;
            }
            if (rightElements.ContainsKey(sourceSender))
            {
                resizeRight = true;
            }
            if (upElements.ContainsKey(sourceSender))
            {
                resizeUp = true;
            }
            if (downElements.ContainsKey(sourceSender))
            {
                resizeDown = true;
            }

            if ((resizeLeft && resizeDown) || (resizeRight && resizeUp))
            {
                setNESWCursor(sender, e);
            }
            else if ((resizeRight && resizeDown) || (resizeLeft && resizeUp))
            {
                setNWSECursor(sender, e);
            }
            else if (resizeLeft || resizeRight)
            {
                setWECursor(sender, e);
            }
            else if (resizeUp || resizeDown)
            {
                setNSCursor(sender, e);
            }
        }

        private void setWECursor(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.SizeWE;
        }

        private void setNSCursor(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.SizeNS;
        }

        private void setNESWCursor(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.SizeNESW;
        }

        private void setNWSECursor(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.SizeNWSE;
        }

        private void setArrowCursor(object sender, MouseEventArgs e)
        {
            if (!resizeDown && !resizeLeft && !resizeRight && !resizeUp)
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void setArrowCursor()
        {
            this.Cursor = Cursors.Arrow;
        }
        #endregion

        #region external call  
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out PointAPI lpPoint);

        private struct PointAPI
        {
            public int X;
            public int Y;
        }
        #endregion


    }
}
