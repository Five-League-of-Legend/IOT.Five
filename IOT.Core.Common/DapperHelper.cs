using System;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace IOT.Core.Common
{
    public class DapperHelper
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(string sql)
        {
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.Conn))
            {
                List<T> list = db.Query<T>(sql).ToList();
                return list;
            }
        }
        /// <summary>
        /// 获取受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Execute(string sql)
        {
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.Conn))
            {
                return db.Execute(sql);
            }
        }
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object Exescalar(string sql)
        {
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.Conn))
            {
                return db.ExecuteScalar(sql);
            }
        }
    }
}
