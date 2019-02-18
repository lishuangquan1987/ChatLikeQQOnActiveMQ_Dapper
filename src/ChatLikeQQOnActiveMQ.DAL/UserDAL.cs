using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using ChatLikeQQOnActiveMQ.Model;
using Dapper;

namespace ChatLikeQQOnActiveMQ.DAL
{
    public class UserDAL : BaseDAL
    {
        private static string tableName = "tb_User";
        public override int Add<T>(T obj)
        {
            if (typeof(T) != typeof(User))
                throw new Exception("Invalid User Type");
            string sql = string.Format("insert into {0} values(UserName=@UserName,Password=@Password,Nick=@Nick,Age=@Age,Gender=@Gender,Icon=@Icon,PersonalizedSignature=@PersonalizedSignature)",tableName);
            using (var conn = ConnectionFactory.GetConnection())
            {
                return conn.Execute(sql, obj);
            }
        }

        public override int Delete<T>(T obj)
        {
            if (typeof(T) != typeof(User))
                throw new Exception("Invalid User Type");
            User u = obj as User;
            string sql = string.Format("Delete from {0} where UserName=@UserName",tableName);
            using (var conn = ConnectionFactory.GetConnection())
            {
                return conn.Execute(sql, obj);
            }
        }

        public override List<T> GetAll<T>()
        {
            if (typeof(T) != typeof(User))
                throw new Exception("Invalid User Type");
            string sql = string.Format("select * from {0}", tableName);
            using (var conn = ConnectionFactory.GetConnection())
            {
                return conn.Query<T>(sql).ToList();
            }
        }
    }
}
