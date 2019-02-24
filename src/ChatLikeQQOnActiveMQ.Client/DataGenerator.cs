using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLikeQQOnActiveMQ.Client
{
   public class DataGenerator:List<ChatLikeQQOnActiveMQ.Model.User>
    {
        
        public DataGenerator()
        {
            this.Add(new Model.User() { UserName="1", PersonalizedSignature="323fsd"});
            this.Add(new Model.User() { UserName = "2", PersonalizedSignature = "323fsd" });
            this.Add(new Model.User() { UserName = "3", PersonalizedSignature = "325553fsd" });
        }
    }
}
