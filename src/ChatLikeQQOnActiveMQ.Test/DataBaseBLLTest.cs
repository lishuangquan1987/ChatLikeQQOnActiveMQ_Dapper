using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatLikeQQOnActiveMQ.Test
{
    class DataBaseBLLTest : ITest
    {
        public void Test()
        {
            ChatLikeQQOnActiveMQ.BLL.DataBaseBLL dataBaseBLL = new BLL.DataBaseBLL();
            dataBaseBLL.InitDataBase();
        }
    }
}
