using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatLikeQQOnActiveMQ.Client
{
    class Bootstrapper: UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<MainWindow>();
        }
        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }
    }
}
