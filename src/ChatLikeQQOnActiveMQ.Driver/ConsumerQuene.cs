using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace ChatLikeQQOnActiveMQ.Driver
{
   public class ConsumerQuene:BaseConnection
    {
        private IMessageConsumer messageConsumer;
        public event Action<string> MessageReceived;
        public ConsumerQuene(string ipStr,string queneName) : base(ipStr)
        {
            InitConsumer(queneName);
        }
        public ConsumerQuene(string ipStr,string queneName, string userName, string password) : base(ipStr, userName, password)
        {
            InitConsumer(queneName);
        }
        private void InitConsumer(string queneName)
        {
            this.connection.Start();
            this.session = connection.CreateSession();
            messageConsumer = session.CreateConsumer(new ActiveMQQueue(queneName));
            messageConsumer.Listener += MessageConsumer_Listener;
        }
        private void MessageConsumer_Listener(IMessage message)
        {
            if (this.MessageReceived != null)
            {
                this.MessageReceived((message as ITextMessage).Text);
            }            
        }
    }
}
