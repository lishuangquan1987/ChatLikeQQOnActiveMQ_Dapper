using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatLikeQQOnActiveMQ.Model
{
   public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Nick { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public byte[] Icon { get; set; }
        public string PersonalizedSignature { get; set; }
    }
}
