using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apache.NMS;
using Apache.NMS.Util;

namespace ChatLikeQQOnActiveMQ.Driver
{
   public class Subscribe:BaseConnection
    {
        private string clientId;
        private IMessageConsumer messageConsumer;
        ITopic destination;
        private string topicName;
        public event Action<string> ReceivedMsg;
        public Subscribe(string ipStr, string clientId,string topicName) : base(ipStr)
        {
            this.clientId = clientId;
            this.topicName = topicName;
            InitSubscribe();
        }
        public Subscribe(string ipStr, string clientId, string topicName,string userName, string password) : base(ipStr, userName, password)
        {
            this.clientId = clientId;
            this.topicName = topicName;
            InitSubscribe();
        }
        private void InitSubscribe()
        {
            connection.Start();
            this.session = connection.CreateSession();
            destination = SessionUtil.GetTopic(session,topicName);
            messageConsumer = session.CreateDurableConsumer(destination,clientId,null,false);
            messageConsumer.Listener += MessageConsumer_Listener;
        }

        private void MessageConsumer_Listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            if (msg != null && ReceivedMsg != null)
            {
                ReceivedMsg(msg.Text);
            }
        }
    }
}
