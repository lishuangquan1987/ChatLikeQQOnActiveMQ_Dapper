using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatLikeQQOnActiveMQ.Model
{
    [Serializable]
    public class MsgModel
    {
        /// <summary>
        /// msgbody
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// the msg time,this is add by server
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// FromClient
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// ToClient
        /// </summary>
        public string To { get; set; }
        public MsgType MsgType { get; set; }
   
    }
    public enum MsgType
    {
        /// <summary>
        /// for point to point chat
        /// </summary>
        P2p,
        /// <summary>
        /// for group chat 
        /// </summary>
        Pubsub,
        /// <summary>
        /// for register
        /// </summary>
        Register,
        
        Login,
        
        AddFriend,

        SearchFriend,

        LoadUserDetail,
    }
}
