using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ChatLikeQQOnActiveMQ.Client
{
   public class MainWindowViewModel:BindableBase
    {
       public ICollectionView FriendList { get; private set; }
        public MainWindowViewModel()
        {

        }
    }
}
