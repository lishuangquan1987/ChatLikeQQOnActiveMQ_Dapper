using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using Dapper;
namespace ChatLikeQQOnActiveMQ.DAL
{
   public abstract class BaseDAL
    {
        public abstract int Add<T>(T obj);
        public abstract int Delete<T>(T obj);
        public abstract List<T> GetAll<T>() where T:class;
        public List<T> GetAll<T>(string sql) where T : class
        {
            using (var conn = ConnectionFactory.GetConnection())
            {
                return conn.Query<T>(sql).ToList();
            }
        }
        public List<T> GetAll<T>(string sql,object paras) where T : class
        {
            using (var conn = ConnectionFactory.GetConnection())
            {
                return conn.Query<T>(sql,paras).ToList();
            }
        }
    }
}
