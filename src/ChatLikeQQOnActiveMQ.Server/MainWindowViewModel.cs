using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ChatLikeQQOnActiveMQ.Server
{
   public class MainWindowViewModel
    {
        private ObservableCollection<PointToPointModel> pointToPointList = new ObservableCollection<PointToPointModel>();
        private ObservableCollection<GroupChatModel> groupChatList = new ObservableCollection<GroupChatModel>();
        public ObservableCollection<PointToPointModel> PointToPointList
        {
            get { return pointToPointList; }
            set { pointToPointList = value; }
        }
        public ObservableCollection<GroupChatModel> GroupChatList
        {
            get { return groupChatList; }
            set { groupChatList = value; }
        }
    }
}
