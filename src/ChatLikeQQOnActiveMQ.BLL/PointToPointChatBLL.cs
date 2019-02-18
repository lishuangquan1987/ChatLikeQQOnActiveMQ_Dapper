using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatLikeQQOnActiveMQ.DAL;
using ChatLikeQQOnActiveMQ.Model;

namespace ChatLikeQQOnActiveMQ.BLL
{
   public class PointToPointChatBLL
    {
        private PointToPointChatDal dal = new PointToPointChatDal();
        public int SaveOneRecord(PointToPoint p)
        {
            return dal.Add(p);
        }
        public int DeleteOneRecord(int ID)
        {
            return dal.Delete(new PointToPoint() { Id = ID });
        }
    }
}
