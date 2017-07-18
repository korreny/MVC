using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace Common
{
    /// <summary>
    /// 数据库访问类
    /// </summary>
    public class DBHeper
    {
     //连接字符串server =182.254.246.11; database = bingwang; uid = sa; pwd = skyteam@2016
      private string constr;
      //  static string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString.ToString();
        public DBHeper(string str)
        {
            constr = str;
        }
        //public DBHeper(DBinfo dbinfo)
        //{
        //    string constr = "server = " + dbinfo.DBip + "; user id = " + dbinfo.Uid + "; password = " + dbinfo.Pwd + "; database = " + dbinfo.DBname + "";
        //}

        /// <summary>
        /// 通用增删改 返回数据库是否受影响
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public  int SQL(string sql, SqlParameter[] ps = null)
        {
            //得到连接对象
            using (SqlConnection conn = new SqlConnection(constr))
            {
                //打开连接
                conn.Open();
                //创建命令对象
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (ps != null)
                        //添加参数
                        cmd.Parameters.AddRange(ps);
                    //执行增删改操作，返回受影响行数
                    int count = cmd.ExecuteNonQuery();
                    //返回数据库是否受影响
                    return count ;
                }
            }
        }

        /// <summary>
        /// 执行SQL,返回单个结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public  object Get(string sql, SqlParameter[] ps = null)
        {
            //得到连接对象
            using (SqlConnection conn = new SqlConnection(constr))
            {
                //打开连接
                conn.Open();
                //创建命令对象
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (ps != null)
                        //添加参数
                        cmd.Parameters.AddRange(ps);
                    //返回结果
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 通用查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public  DataTable Select(string sql, SqlParameter[] ps = null)
        {
            //创建连接对象
            using (SqlConnection conn = new SqlConnection(constr))
            {
                //创建数据适配器
                using (SqlDataAdapter sda = new SqlDataAdapter(sql, conn))
                {
                    if(ps != null)
                        //添加参数
                    sda.SelectCommand.Parameters.AddRange(ps);
                    //创建数据集对象
                    DataSet ds = new DataSet();
                    //填充数据集
                    sda.Fill(ds);
                    //返回数据集中的第一张表
                    return ds.Tables[0];
                }
            }
        }
    }
}
