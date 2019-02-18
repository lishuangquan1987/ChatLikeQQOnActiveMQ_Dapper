using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apache.NMS;
using Apache.NMS.Util;
namespace ChatLikeQQOnActiveMQ.Driver
{   
    /// <summary>
    /// pub
    /// </summary>
   public class Publisher:BaseConnection
    {
        private string topicName;
        private IDestination destination;
        private IMessageProducer messageProducer;
        public Publisher(string ipStr,string topicName) : base(ipStr)
        {
            this.topicName = topicName;
            InitProducerTopic();
        }
        public Publisher(string ipStr,string topicName, string userName, string password) : base(ipStr, userName, password)
        {
            this.topicName = topicName;
            InitProducerTopic();
        }
        private void InitProducerTopic()
        {
            this.connection.Start();
            this.session = this.connection.CreateSession();
            destination = SessionUtil.GetTopic(session,topicName);
            messageProducer = session.CreateProducer(destination);
            messageProducer.DeliveryMode = MsgDeliveryMode.Persistent;
        }
        public void SendMsg(string msg)
        {
            ITextMessage message = session.CreateTextMessage(msg);
            messageProducer.Send(message, MsgDeliveryMode.Persistent, MsgPriority.Normal,TimeSpan.FromDays(7));
        }

    }
}
