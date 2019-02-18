using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatLikeQQOnActiveMQ.Server
{
   public class PointToPointModel
    {
        public DateTime DateTime  { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
    }
}
