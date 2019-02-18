using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatLikeQQOnActiveMQ.Driver;

namespace ChatLikeQQOnActiveMQ.Test
{
    public class SubscribeTest : ITest
    {
        public void Test()
        {
            Console.WriteLine("请输入ClientId:");
            string clientId = Console.ReadLine();
            Console.WriteLine("初始化subscibe");
            
            Subscribe subscribe = new Subscribe("localhost:61616",clientId,"Test20180503");
            subscribe.ReceivedMsg += Subscribe_ReceivedMsg;
            Console.ReadLine();
        }

        private void Subscribe_ReceivedMsg(string obj)
        {
            Console.WriteLine("收到："+obj);
        }
    }
}
