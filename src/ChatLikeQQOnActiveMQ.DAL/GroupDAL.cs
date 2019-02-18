using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatLikeQQOnActiveMQ.Model;
using System.Data.SQLite;
using Dapper;
namespace ChatLikeQQOnActiveMQ.DAL
{
    public class GroupDAL : BaseDAL
    {
        private static string tableName = "tb_Group";
        
        public override int  Add<T>(T obj)
        {
            if (typeof(Group) != obj.GetType())
                throw new Exception("Invalid Group type!");
            string sql = string.Format("insert into {0} values(GroupName=@GroupName,Description=@Description)",tableName);
            using (var conn = ConnectionFactory.GetConnection())
            {
                return conn.Execute(sql,obj);
            }

        }

        public override int Delete<T>(T obj)
        {
            if (typeof(Group) != obj.GetType())
                throw new Exception("Invalid Group Type!");
            string sql = string.Format("Delete from {0} where GroupName=@GroupName",tableName);
            using (var conn = ConnectionFactory.GetConnection())
            {
                return conn.Execute(sql,obj);
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
