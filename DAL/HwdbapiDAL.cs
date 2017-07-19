using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetDBInfo.Model;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using com.iflysse.helper;
using Table.Common;

namespace GetDBInfo.DAL
{
    /// <summary>
    /// 创建时间:2017年7月18日19:25:18
    /// 作者:hello
    /// 功能:DAL层,提供对数据库的增删查改
    /// </summary>
    public class HwdbapiDAL
    {
        static string ConnectionString = "server = " + ConfigurationManager.AppSettings["ResultDBIP"] + "; user id = " + ConfigurationManager.AppSettings["ResultDBUid"] + "; password = " + ConfigurationManager.AppSettings["ResultDBPwd"] + "; database = " + ConfigurationManager.AppSettings["ResultDBName"] + "";
        Table.Common.MySQLHelper mysql = new Table.Common.MySQLHelper(ConnectionString);
        DBHeper sqlserver = new DBHeper(ConnectionString);
        //string outTableName;//= ConfigurationManager.AppSettings["ResultTableName"];

        public DataTable SelectAll()
        {
            string sql = string.Format(@"select * from {0}", ConfigurationManager.AppSettings["ResultTableName"]);
            if (Convert.ToInt32(ConfigurationManager.AppSettings["ResultDBType"]) == 1)
            {
                return sqlserver.Select(sql);
            }
            else
            {
                try
                {
                    return mysql.Query(sql);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int? Insert(Hwdbapi table)
        {
            // outTableName = ConfigurationManager.AppSettings["ResultTableName"];
            string sql = string.Format(@"Insert into {6}
                                           ( tableid,EnTableName,Field,Type,IsDelete,CreateTime) 
                                     values('{0}','{1}','{2}','{3}','{4}','{5}')",
                                   table.Tableid, table.EnTableName, table.Field, table.Type, table.IsDelete, table.CreateTime, ConfigurationManager.AppSettings["ResultTableName"]);
            if (Convert.ToInt32(ConfigurationManager.AppSettings["ResultDBType"]) == 1)
            {
                return sqlserver.SQL(sql);
            }
            else
            {
                try
                {
                    return mysql.ExecuteSql(sql);
                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int SQL(string sql)
        {
            if (Convert.ToInt32(ConfigurationManager.AppSettings["ResultDBType"]) == 1)
            {
                return sqlserver.SQL(sql);

            }
            else
            {
                try
                {
                    return mysql.ExecuteSql(sql);
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetTableType(string tableName)
        {
            if (Convert.ToInt32(ConfigurationManager.AppSettings["ResultDBType"]) == 1)
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                try
                {
                    conn.Open();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    // Console.WriteLine("数据库连接失败,按任意键退出...");
                    // Console.Read();
                    return null;
                }
                //string temp = string.Format(@"select Name from sysobjects where xtype = 'U' and Name = '{0}'", ConfigurationManager.AppSettings["ResultTableName"]);

                SqlCommand com = new SqlCommand("select name from syscolumns where id=Object_Id('" + ConfigurationManager.AppSettings["ResultTableName"] + "')", conn);
                SqlDataAdapter adaper = new SqlDataAdapter(com);
                System.Data.DataTable res = new System.Data.DataTable();
                adaper.Fill(res);
                //System.Data.DataTable dt = conn.GetSchema("Tables", null);
                conn.Close();
                return res;

            }
            else
            {
                MySqlConnection conn;
                conn = new MySqlConnection(ConnectionString);
                try
                {
                    conn.Open();
                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                    //Console.WriteLine("数据库连接失败,按任意键退出...");
                    //Console.Read();
                    return null;
                }
                string temp = string.Format(@"select TABLE_NAME from information_schema.tables where TABLE_SCHEMA='{0}' and TABLE_NAME= '{1}'", ConfigurationManager.AppSettings["ResultDBName"], ConfigurationManager.AppSettings["ResultTableName"]);
                //   SqlCommand com = new SqlCommand("select column_name,data_type from information_schema.columns where table_name in ()" + tableName + "'", conn);
                MySqlDataAdapter adaper = new MySqlDataAdapter("select column_name,data_type from information_schema.columns where table_name in(" + temp + ")", conn);
                System.Data.DataTable res = new System.Data.DataTable();
                adaper.Fill(res);
                conn.Close();
                return res;
            }
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public int? UpDate(Hwdbapi table)
        {
            // outTableName = ConfigurationManager.AppSettings["ResultTableName"];
            string sql = string.Format(@"update  {5} set
                                      Type='{0}',IsDelete='{1}',ReviseTime=NULL where EnTableName= '{3}' and Field='{4}' ",
                                     table.Type, table.IsDelete, table.ReviseTime, table.EnTableName, table.Field, ConfigurationManager.AppSettings["ResultTableName"]);
            if (Convert.ToInt32(ConfigurationManager.AppSettings["ResultDBType"]) == 1)
            {
                try
                {
                    return sqlserver.SQL(sql);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                try
                {
                    return mysql.ExecuteSql(sql);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }



        /// <summary>
        /// 找出最大的tableid
        /// </summary>
        /// <returns></returns>
        public DataTable FindMaxBytid()
        {
            // outTableName = ConfigurationManager.AppSettings["ResultTableName"];
            //select max(tableid) from hwdbapi
            string sql = string.Format(@"select max(tableid) from {0}", ConfigurationManager.AppSettings["ResultTableName"]);
            if (Convert.ToInt32(ConfigurationManager.AppSettings["ResultDBType"]) == 1)
            {
                try
                {
                    return sqlserver.Select(sql);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                try
                {
                    return mysql.Query(sql);
                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }


        /// <summary>
        ///  找出指定表名的id
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable SelectBytid(string tableName)
        {
            // outTableName = ConfigurationManager.AppSettings["ResultTableName"];
            string sql = string.Format(@"select tableid from {1} where entablename='{0}' ", tableName, ConfigurationManager.AppSettings["ResultTableName"]);
            if (Convert.ToInt32(ConfigurationManager.AppSettings["ResultDBType"]) == 1)
            {
                try
                {
                    return sqlserver.Select(sql);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                try
                {
                    return mysql.Query(sql);
                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }


        /// <summary>
        /// 设置删除标志
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int? SetDel(string tableName)
        {
            string sql = string.Format(@"update  {2} set isdelete='1' ,ReviseTime='{1}' where entablename='{0}' ", tableName, DateTime.Now, ConfigurationManager.AppSettings["ResultTableName"]);
            if (Convert.ToInt32(ConfigurationManager.AppSettings["ResultDBType"]) == 1)
            {
                try
                {
                    return sqlserver.SQL(sql);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                try
                {
                    return mysql.ExecuteSql(sql);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

    }
}
