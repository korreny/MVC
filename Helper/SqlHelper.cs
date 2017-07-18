using System;
using System.Collections.Generic;
using System.Text;
using Com.iFlytek.DatabaseAccess.DAL;
using System.Data.SqlClient;
using System.Data;

namespace com.iflysse.helper
{
    /// <summary>
    /// FileName: SqlHelper.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: dlli5
    /// Corporation: 
    /// Description: 
    /// DateTime: 2014/5/19 15:51:02
    /// </summary>
    public class SqlHelper : SqlCommonHelper
    {
        public static object ExecuteScalar(string sql, SqlParameter[] sqlParameter)
        {
            LoadSqlParameter(sqlParameter);
            return _IflytekDBAccess.ExecuteScalar(BoName, System.Data.CommandType.Text, sql, sqlParameter);
        }

        public static int ExecuteNonQuery(string sql, SqlParameter[] sqlParameter)
        {
            LoadSqlParameter(sqlParameter);
            return _IflytekDBAccess.ExecuteNonQuery(BoName, System.Data.CommandType.Text, sql, sqlParameter);
        }

        public static DataSet ExecuteDataset(string sql, SqlParameter[] sqlParameter)
        {
            LoadSqlParameter(sqlParameter);
            return _IflytekDBAccess.ExecuteDataset(BoName, System.Data.CommandType.Text, sql, sqlParameter);
        }

        public static DataSet ExecuteSp(string spName, SqlParameter[] sqlParameter)
        {
            LoadSqlParameter(sqlParameter);
            return _IflytekDBAccess.ExecuteDataset(BoName, spName, sqlParameter);
        }

        public static object ExecuteScalarOfSp(string spName, SqlParameter[] sqlParameter)
        {
            LoadSqlParameter(sqlParameter);
            return _IflytekDBAccess.ExecuteScalar(BoName, spName, sqlParameter);
        }

        public static int ExecuteNonQueryOfSP(string spName, SqlParameter[] sqlParameter)
        {
            LoadSqlParameter(sqlParameter);
            return _IflytekDBAccess.ExecuteNonQuery(BoName, spName, sqlParameter);
        }
    }
}
