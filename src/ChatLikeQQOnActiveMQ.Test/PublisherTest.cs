using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatLikeQQOnActiveMQ.Driver;

namespace ChatLikeQQOnActiveMQ.Test
{
    public class PublisherTest : ITest
    {
        public void Test()
        {
            Console.WriteLine("初始化Publisher。。。");
            Publisher publisher = new Publisher("localhost:61616","Test20180503");
            while (true)
            {
                Console.WriteLine("请输入字符串来广播:");
                string msg = Console.ReadLine();
                publisher.SendMsg(msg);
            }

        }
    }
}
