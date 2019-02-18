using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apache.NMS.ActiveMQ;
using Apache.NMS;

namespace ChatLikeQQOnActiveMQ.Driver
{
   public abstract class BaseConnection:IDisposable
    {
        protected IConnectionFactory connectionFactory;
        protected IConnection connection;
        protected ISession session;
        public BaseConnection(string ipStr)
        {
            this.connectionFactory = new ConnectionFactory(string.Format("tcp://{0}/",ipStr));
            this.connection = this.connectionFactory.CreateConnection();
        }
        public BaseConnection(string ipStr, string userName, string password)
        {
            this.connectionFactory = new ConnectionFactory(string.Format("tcp://{0}/", ipStr));
            this.connection = this.connectionFactory.CreateConnection(userName,password);
        }

        public void Dispose()
        {
            this.session.Close();
            this.connection.Close();
        }
    }
}
