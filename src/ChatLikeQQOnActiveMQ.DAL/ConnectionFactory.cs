using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace ChatLikeQQOnActiveMQ.DAL
{
   public class ConnectionFactory
    {
        private static string connStr = "Data Source=ChatLikeQQOnActiveMQ.db;Pooling=true;FailIfMissing=false";
        public static System.Data.IDbConnection GetConnection()
        {
            return new SQLiteConnection(connStr);
        }
    }
}
