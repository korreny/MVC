using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;
using GetDBInfo.Model;
using com.iflysse.helper;

namespace GetDBInfo.DAL
{
    /// <summary>
    /// 创建时间:2017年7月18日19:26:38
    /// 作者:hello
    /// 功能:DAL层,对数据库的增删查改
    /// </summary>
    public class DBinfoDAL
    {
        DBinfo db;
        string ConnectionString;
        public DBinfoDAL(DBinfo dbinfo)
        {
            db = dbinfo;
            ConnectionString = "server = " + dbinfo.DBip + "; user id = " + dbinfo.Uid + "; password = " + dbinfo.Pwd + "; database = " + dbinfo.DBname + "";
        }
        /// <summary>
        /// 获取所有表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetTables()
        {
            if (db.DBtype == 1)
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                try
                {
                    conn.Open();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    // Console.WriteLine("数据库连接失败,按任意键退出...");
                    return null;
                }
                System.Data.DataTable dt = conn.GetSchema("Tables", null);
                conn.Close();
                return dt;
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
                    return null;
                }
              
                    System.Data.DataTable dt = conn.GetSchema("Tables", null);
                    conn.Close();
                    return dt;
               
              
            }
        }
        /// <summary>
        /// 获取表的类型
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetTableType(string tableName)
        {
            if (db.DBtype == 1)
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
                // string temp = string.Format(@"select TABLE_NAME from information_schema.tables where TABLE_SCHEMA='{0}' and TABLE_NAME= '{1}'", ConfigurationManager.AppSettings["DBName"], ConfigurationManager.AppSettings["ResultTableName"]);

                SqlCommand com = new SqlCommand("select column_name, data_type from information_schema.columns where table_name = '" + tableName + "'", conn);
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
                string temp = string.Format(@"select TABLE_NAME from information_schema.tables where TABLE_SCHEMA='{0}' and TABLE_NAME= '{1}'", ConfigurationManager.AppSettings["DBName"], tableName);
                try
                {
                    MySqlDataAdapter adaper = new MySqlDataAdapter("select column_name,data_type from information_schema.columns where table_name in(" + temp + ")", conn);
                    System.Data.DataTable res = new System.Data.DataTable();
                    adaper.Fill(res);
                    conn.Close();
                    return res;
                }catch(MySql.Data.MySqlClient.MySqlException e)
                {
                    return null;
                }
               
            }
        }

    }
}
