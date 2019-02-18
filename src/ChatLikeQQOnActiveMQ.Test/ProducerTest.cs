using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatLikeQQOnActiveMQ.Driver;

namespace ChatLikeQQOnActiveMQ.Test
{
    public class ProducerTest : ITest
    {
        public void Test()
        {
            Console.WriteLine("初始化Producer。。。");
            ProducerQuene producer = new ProducerQuene("localhost:61616","TestQuene");
            while (true)
            {
                Console.WriteLine("请输入字符来发送到队列：");
                string msg = Console.ReadLine();
                producer.SendMsg(msg);
                Console.WriteLine("发送完毕！");
            }
        }
    }
}
