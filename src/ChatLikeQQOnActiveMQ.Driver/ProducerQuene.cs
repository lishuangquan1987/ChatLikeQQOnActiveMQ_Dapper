using Apache.NMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatLikeQQOnActiveMQ.Driver
{
    /// <summary>
    /// 生产者
    /// </summary>
   public class ProducerQuene:BaseConnection 
    {
        private IMessageProducer messageProducer;
        public ProducerQuene(string ipStr, string queneName) : base(ipStr)
        {
            InitProducer(queneName);
        }
        public ProducerQuene(string ipStr, string queneName, string userName, string password) : base(ipStr, userName, password)
        {
            InitProducer(queneName);
        }
        private void InitProducer(string queneName)
        {
            this.session = this.connection.CreateSession();
            var quene= new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(queneName);
            messageProducer = session.CreateProducer(quene);
        }
        public void SendMsg(string msg)
        {
            ITextMessage message = messageProducer.CreateTextMessage();
            message.Text = msg;
            messageProducer.Send(message, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);
        }
    }
}
