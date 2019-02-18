using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ChatLikeQQOnActiveMQ.DAL;

namespace ChatLikeQQOnActiveMQ.BLL
{
    public class DataBaseBLL
    {
        private static string dataBaseFile = Path.Combine(System.Windows.Forms.Application.StartupPath, "ChatLikeQQOnActiveMQ.db");
        private DataBaseDal dataBaseDal = new DataBaseDal();
        /// <summary>
        /// 初始化DB数据库，没有则创建
        /// </summary>
        public void InitDataBase()
        {
            if (File.Exists(dataBaseFile))
                return;
            //1.Create data base
            dataBaseDal.CreateDataBase(dataBaseFile);
            //2.Create tables
            List<string> sqlList = new List<string>();
            //tb_User
            string sql = @"CREATE TABLE tb_User
                        (
                        UserName              VARCHAR(50)  PRIMARY KEY NOT NULL UNIQUE,                                                                                                                       
                        Password              VARCHAR(50)  NOT NULL,
                        Nick                  VARCHAR(100),
                        Age                   INTEGER,
                        Gender                VARCHAR(50),
                        Icon                  BLOB,
                        PersonalizedSignature VARCHAR(255)
                        );";
            sqlList.Add(sql);
            //tb_PointToPoint
            sql= @"CREATE TABLE tb_PointToPointChatRecord (
                    Id INTEGER   PRIMARY KEY AUTOINCREMENT,
                    [From] VARCHAR(50)  NOT NULL,
                    [To]    VARCHAR(50)  NOT NULL,
                    Time    DATETIME,
                    Content VARCHAR(255)
                    );";
            sqlList.Add(sql);
            //tb_Group
            sql = @"Create table tb_Group
            (
                Id INTEGER PRIMARY KEY,
                GroupName varchar(50) unique not null,
                Description varchar(255)
            )";
            sqlList.Add(sql);
            //tb_GroupMember
            sql = @" Create table tb_GroupMember
            (
                GroupId integer,
                UserName varchar(50)
            )";
            sqlList.Add(sql);
            //tb_FriendShip
            sql = @"Create table tb_FriendShip
                    (
                        UserName1 varchar(50),
                        UserName2 varchar(50),
                        Time datetime
                    )";
            sqlList.Add(sql);
         
            dataBaseDal.CreateTables(sqlList.ToArray());
        }
    }
}
