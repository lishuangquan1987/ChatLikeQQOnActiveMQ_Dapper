using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatLikeQQOnActiveMQ.Model;
using System.Data.SQLite;
using Dapper;

namespace ChatLikeQQOnActiveMQ.DAL
{
    public class PointToPointChatDal : BaseDAL
    {
        private string tableName = "tb_PointToPointChatRecord";
        
            
        public override int Add<T>(T obj)
        {
            if (typeof(T) != typeof(PointToPoint))
                throw new Exception("Invalid PointToPoint type");
            string sql =string.Format("insert into {0} values(From=@From,To=@To,Time=@Time,Content=@Content)",tableName);
            using (var conn = ConnectionFactory.GetConnection())
            {
                return conn.Execute(sql,obj);
            }
        }

        public override int Delete<T>(T obj)
        {
            if (typeof(T) != typeof(PointToPoint))
                throw new Exception("Invalid PointToPoint type");
            string sql =string.Format( "delete from {0} where ID=@ID",tableName);
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
