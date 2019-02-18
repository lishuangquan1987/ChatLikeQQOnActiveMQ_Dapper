using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatLikeQQOnActiveMQ.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ITest test = null;

            #region Producer Test
            //test = new ProducerTest();
            #endregion

            #region Consumer Test
            //test = new ConsumerTest(); 
            #endregion

            #region SubscribeTest
            //test = new SubscribeTest();
            #endregion

            #region PublisherTest

            //test = new PublisherTest();
            #endregion

            #region DataBaseBLL
            test =new  DataBaseBLLTest();
            #endregion
            test.Test();

        }
    }
}
