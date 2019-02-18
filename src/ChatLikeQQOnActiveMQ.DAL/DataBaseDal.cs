using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace ChatLikeQQOnActiveMQ.DAL
{
    public class DataBaseDal
    {
        public void CreateDataBase(string databaseName)
        {
            System.Data.SQLite.SQLiteConnection.CreateFile(databaseName);
        }
        public void CreateTables(string[] sqls)
        {
            using (var conn = ConnectionFactory.GetConnection())
            {
                var trans = conn.BeginTransaction();
                try
                {
                    foreach (var sql in sqls)
                    {
                        conn.Execute(sql, null, trans);
                    }
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
    }
}
