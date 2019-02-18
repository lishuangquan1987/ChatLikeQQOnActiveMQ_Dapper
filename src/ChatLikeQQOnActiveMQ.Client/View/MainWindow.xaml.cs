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
using ChatLikeQQOnActiveMQ.Model;

namespace ChatLikeQQOnActiveMQ.Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowResizer
    {
        public User CurrentUser;
        public MainWindow()
        {
            LoginForm loginForm = new LoginForm();
            bool? result = loginForm.ShowDialog();
            if (result.HasValue && result.Value)
            {
                CurrentUser = loginForm.CurrentUser;
                InitializeComponent();
            }
            else
            {
                Environment.Exit(Environment.ExitCode);
            }
            InitializeComponent();
        }


        private void WindowResizer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void WindowResizer_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
