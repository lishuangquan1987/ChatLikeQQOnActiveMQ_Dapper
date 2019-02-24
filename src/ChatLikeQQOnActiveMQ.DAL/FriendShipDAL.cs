using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatLikeQQOnActiveMQ.Model;
using System.Data.SQLite;
using Dapper;

namespace ChatLikeQQOnActiveMQ.DAL
{
    public class FriendShipDAL : BaseDAL
    {
        private static string tableName = "tb_FriendShip";
        public override int Add<T>(T obj)
        {
            if (typeof(T) != typeof(FriendShip))
                throw new Exception("invalid FriendShip type");
            var sql = string.Format("insert into {0} values(@UserName1,@UserName2,@Time)",tableName);
            using (var conn = ConnectionFactory.GetConnection())
            {
                return conn.Execute(sql, obj);
            }
        }

        public override int Delete<T>(T obj)
        {
            if (typeof(T) != typeof(FriendShip))
                throw new Exception("invalid FriendShip type");
            FriendShip friendShip = obj as FriendShip;
            string sql = string.Format("Delete from {0} where (UserName1=@UserName1 and UserName2=@UserName2) or(UserName2=@UserName1 and @UserName1=@UserName2)",tableName);
            using (var conn = ConnectionFactory.GetConnection())
            {
                return conn.Execute(sql, obj);
            }
        }

        public override List<T> GetAll<T>()
        {
            string sql = string.Format("select * from {0}", tableName);
            using (var conn = ConnectionFactory.GetConnection())
            {
                return conn.Query<T>(sql).ToList();
            }
        }
    }
}
