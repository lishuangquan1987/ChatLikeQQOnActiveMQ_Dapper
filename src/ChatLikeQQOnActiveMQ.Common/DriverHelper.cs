using ChatLikeQQOnActiveMQ.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatLikeQQOnActiveMQ.Common
{
    public class DriverHelper
    {
        private static string ipStr = System.Configuration.ConfigurationManager.AppSettings["IpStr"];
        public static void SendMsgToQuene(string queneName, string msg)
        {
            using (ProducerQuene producer = new ProducerQuene(ipStr, queneName))
            {
                producer.SendMsg(msg);
            }
        }
        public static void SendMsgToTopic(string topic, string msg)
        {
            using (Publisher publisher = new Publisher(ipStr, topic))
            {
                publisher.SendMsg(msg);
            }
        }
    }
}
