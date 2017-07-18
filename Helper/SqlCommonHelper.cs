using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Com.iFlytek.DatabaseAccess.DAL;

namespace com.iflysse.helper
{
    /// <summary>
    /// FileName: SqlCommonHelper.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: dlli5
    /// Corporation: 
    /// Description: ConnectionString
    /// DateTime: 2014/5/19 15:43:00
    /// </summary>
    public class SqlCommonHelper
    {
        public static SqlDBAccess _IflytekDBAccess = new SqlDBAccess();

        public static string BoName = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        /// <summary>
        /// 通用查询存储过程
        /// </summary>
        /// <param name="comHelp">查询条件等参数实体类</param>
        /// <returns>DataTable</returns>
        public static DataTable ComSelect(ref ComHelp comHelp)
        {
            try
            {
                //存储过程名称
                string strsql = "Common_Select";
                SqlParameter[] sqlparam =
                {
					new SqlParameter("@TableName",SqlDbType.NVarChar), 
                     new SqlParameter("@WithSql",SqlDbType.NVarChar), 
                    new SqlParameter("@SelectList ",SqlDbType.NVarChar), 
                    new SqlParameter("@SearchCondition",SqlDbType.NVarChar), 
                    new SqlParameter("@OrderExpression",SqlDbType.NVarChar), 
                    new SqlParameter("@PageIndex",SqlDbType.Int), 
                    new SqlParameter("@PageSize",SqlDbType.Int), 
                    new SqlParameter("@TotalCount",SqlDbType.Int), 
                    new SqlParameter("@TotalPages",SqlDbType.Int)
                };

                int i = 0;
                sqlparam[i++].Value = comHelp.TableName;
                sqlparam[i++].Value = comHelp.WithSql;
                sqlparam[i++].Value = comHelp.SelectList;
                sqlparam[i++].Value = comHelp.SearchCondition;
                sqlparam[i++].Value = comHelp.OrderExpression;
                sqlparam[i++].Value = comHelp.PageIndex;
                sqlparam[i++].Value = comHelp.PageSize;
                sqlparam[i++].Value = comHelp.TotalCount;
                sqlparam[i++].Value = comHelp.TotalPages;
                sqlparam[--i].Direction = ParameterDirection.Output;
                sqlparam[--i].Direction = ParameterDirection.Output;
                //执行存储过程
                DataSet ds = (DataSet)_IflytekDBAccess.ExecuteDataset(BoName, CommandType.StoredProcedure, strsql, sqlparam);
                comHelp.TotalCount = 0;
                comHelp.TotalPages = 0;
                if (sqlparam[7].Value != null)
                {
                    comHelp.TotalCount = int.Parse(sqlparam[7].Value.ToString());
                }
                if (sqlparam[8].Value != null)
                {
                    comHelp.TotalPages = int.Parse(sqlparam[8].Value.ToString());
                }
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                //Tracing.Error(this, e);
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlParameter"></param>
        public static void LoadSqlParameter(SqlParameter[] sqlParameter)
        {
            if (sqlParameter == null)
            {
                return;
            }
            foreach (var p in sqlParameter)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }
        }
    }

    /// <summary>
    /// 分页对象实体
    /// </summary>
    [Serializable]
    public class ComHelp
    {
        /// <summary>
        /// 默认构造方法
        /// </summary>
        public ComHelp()
        {
            // todo
            orderExpression = "";
            pageIndex = 0;
            selectList = "*";
            WithSql = "";
        }

        public string WithSql { set; get; }

        /// <summary>
        /// 表名
        /// </summary>
        string tableName;

        /// <summary>
        /// 欲选择字段列表
        /// </summary>
        string selectList;

        /// <summary>
        /// 查询条件
        /// </summary>
        string searchCondition;

        /// <summary>
        /// 排序表达式
        /// </summary>
        string orderExpression;

        /// <summary>
        /// 页号,从0开始
        /// </summary>
        int pageIndex;

        /// <summary>
        /// 页大小
        /// </summary>
        int pageSize;

        /// <summary>
        /// 页面总数
        /// </summary>
        int totalCount;

        /// <summary>
        /// 页面总数
        /// </summary>
        int totalPages;

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        /// <summary>
        /// 欲选择字段列表
        /// </summary>
        public string SelectList
        {
            get { return selectList; }
            set { selectList = value; }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string SearchCondition
        {
            get { return searchCondition; }
            set { searchCondition = value; }
        }

        /// <summary>
        /// 排序表达式
        /// </summary>
        public string OrderExpression
        {
            get { return orderExpression; }
            set { orderExpression = value; }
        }

        /// <summary>
        /// 页号,从0开始
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// 页面总数
        /// </summary>
        public int TotalCount
        {
            get { return totalCount; }
            set { totalCount = value; }
        }

        /// <summary>
        /// 页面总数
        /// </summary>
        public int TotalPages
        {
            get { return totalPages; }
            set { totalPages = value; }
        }

    }
}
