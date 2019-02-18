using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatLikeQQOnActiveMQ.DAL;
using System.Data.SQLite;
using ChatLikeQQOnActiveMQ.Model;

namespace ChatLikeQQOnActiveMQ.BLL
{
    public class UserBLL
    {
        private UserDAL dal = new UserDAL();

        public bool Login(string userName, string password, out string msg)
        {
            msg = "";
            try
            {
                string sql = "select * from tb_User where UserName=@UserName";
                var result = dal.GetAll<User>(sql,new { UserName=userName});
                if (result == null||result.Count<1)
                {
                    msg = "用户名：" + userName + "不存在！";
                    return false;
                }
                if (result[0].Password != password)
                {
                    msg = "密码错误";
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                msg = e.Message + e.StackTrace;
                return false;
            }
        }
        public bool Register(User u, out string msg)
        {
            try
            {
                msg = "";
                int result = dal.Add(u);
                if (result != 1)
                {
                    msg = "返回值不为1，注册失败！";
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                msg = e.Message + e.StackTrace;
                return false;
            }
        }
        public User GetUser(string userName)
        {
            string sql = "select * from tb_user where username=@username";
            var result = dal.GetAll<User>(sql,new { username=userName});
            if (result != null && result.Count > 0)
            {
                return result[0];
            }
            else
            {
                return null;
            }
        }
    }
}
