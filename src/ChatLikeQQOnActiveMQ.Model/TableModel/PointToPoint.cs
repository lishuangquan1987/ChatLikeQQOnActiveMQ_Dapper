using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatLikeQQOnActiveMQ.Model
{
   public class PointToPoint
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
    }
}
