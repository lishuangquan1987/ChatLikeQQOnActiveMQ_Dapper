using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatLikeQQOnActiveMQ.Model
{
   public class UserInfo
    {
        /// <summary>
        /// user name for login ,unique
        /// </summary>
        public string UserName { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }
        public Gender Gender { get; set; }
        public byte[] Icon { get; set; }
        public string PersonalizedSignature { get; set; }

    }
    public enum Gender
    {
        Girl,
        Boy
    }
}
