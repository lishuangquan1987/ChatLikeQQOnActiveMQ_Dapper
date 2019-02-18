using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatLikeQQOnActiveMQ.Driver;

namespace ChatLikeQQOnActiveMQ.Test
{
    public class ConsumerTest : ITest
    {
        public void Test()
        {
            Console.WriteLine("初始化Consumer...");
            ConsumerQuene consumer = new ConsumerQuene("localhost:61616", "TestQuene");
            consumer.MessageReceived += Consumer_MessageReceived;
            Console.Read();
        }

        private void Consumer_MessageReceived(string obj)
        {
            Console.WriteLine("收到："+obj);
        }
    }
}
