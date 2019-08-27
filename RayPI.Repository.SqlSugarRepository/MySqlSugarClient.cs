﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.SqlSugarRepository
{
    public class MySqlSugarClient
    {
        public MySqlSugarClient()
        {
            var connectionConfig = new ConnectionConfig
            {
                ConnectionString = "server=.;uid=sa;pwd=Admin,123;database=RayPI",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            };
            Client = new SqlSugarClient(connectionConfig);
            SimpleClient = Client.GetSimpleClient();
        }

        public SqlSugarClient Client { get; private set; }

        public SimpleClient SimpleClient { get; private set; }

        /// <summary>
        /// 生成实体类
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool CreateEntity(string entityName, string filePath)
        {
            try
            {
                this.Client.DbFirst
                    .IsCreateAttribute()
                    .Where(entityName)
                    .CreateClassFile(filePath, "RayPI.Entity");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
