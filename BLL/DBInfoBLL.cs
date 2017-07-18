using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetDBInfo.Model;
using System.Data;
using GetDBInfo.DAL;

namespace GetDBInfo.BLL
{
    /// <summary>
    /// 创建时间:2017年7月18日19:28:54
    /// 作者:hello
    /// 功能:BLL层,为UI提供一些操作
    /// </summary>
    public class DBInfoBLL
    {
        static public DBinfo dbinfo;
        public DBInfoBLL(DBinfo db)
        {
            dbinfo = db;
        }
        //public int CreateTable(string tableName)
        //{
        //    string sql =

        //}
        DBinfoDAL dal = new DBinfoDAL(dbinfo);

        /// <summary>
        /// 获取所有表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTables()
        {
            return dal.GetTables();
        }

        /// <summary>
        /// 获取表的类型
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetTableType(string tableName)
        {
            return dal.GetTableType(tableName);
        }


    }
}
