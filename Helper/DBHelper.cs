using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using com.iflysse.helper;


namespace com.iflysse.helper
{
    /// <summary>
    /// 基础DAL
    /// </summary>
    public class DBHelper
    {

         //连接字符串
        static string constr = ConfigHelper.GetConnectionString("ConnectionString");

        /// <summary>
        /// 通用增删改 返回数据库是否受影响
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static Boolean SQL(string sql, SqlParameter[] ps = null)
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
                    return count > 0;
                }
            }
        }

        /// <summary>
        /// 执行SQL,返回单个结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object Get(string sql, SqlParameter[] ps = null)
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
        public static DataTable Select(string sql, SqlParameter[] ps = null)
        {
            //创建连接对象
            using (SqlConnection conn = new SqlConnection(constr))
            {
                //创建数据适配器
                using (SqlDataAdapter sda = new SqlDataAdapter(sql, conn))
                {
                    if (ps != null)
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
