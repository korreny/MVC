using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetDBInfo.Model;
using GetDBInfo.DAL;
using System.Data;
using System.Configuration;
namespace GetDBInfo.BLL
{
    /// <summary>
    /// 创建时间:2017年7月18日19:27:35
    /// 作者:hello
    /// 功能:BLL层,为UI提供一些方法
    /// </summary>
    public class HwdbapiBLL
    {
        HwdbapiDAL hwdal = new HwdbapiDAL();

        //public int? CheckStatu()
        //{
        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int CreateTable(string tableName)
        {
            string sql = "";
            if (Convert.ToInt32(ConfigurationManager.AppSettings["ResultDBType"]) == 1)
            {
                //sql = string.Format("CREATE TABLE [dbo].[{0}] ([Id] int NOT NULL IDENTITY(1, 1),[TableId] int NULL,[EnTableName] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL,[CnTableName] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL,[Field] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL,[Type] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL,[Name] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL,[Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL,[IsDelete] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL,[CreateTime] datetime2(7) NULL,[ReviseTime] datetime2(7) NULL,CONSTRAINT[PK__{0}__3214EC075441852A] PRIMARY KEY([Id]))ON[PRIMARY] DBCC CHECKIDENT(N'[dbo].[{0}]', RESEED, 13)", tableName);
                sql = string.Format("CREATE TABLE [dbo].[{0}] ([Id] int NOT NULL IDENTITY(1,1) ,[TableId] int NULL ,[EnTableName] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL ,[CnTableName] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL ,[Field] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL ,[Type] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL ,[Name] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL ,[Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL ,[CreateTime] datetime2(7) NULL ,[ReviseTime] datetime2(7) NULL ,[IsPass] int NULL DEFAULT ((0)) ,[IsDelete] int NULL ,[AuditorId] int NULL ,[AuditorName] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL ,[AuditorIp] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL ,[AuditorMac] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL ,[PassTime] datetime2(7) NULL ,[SubmitterId] int NULL ,[SubmitterName] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL ,[SubmitterIp] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL ,[SubmitterMac] nvarchar(255) COLLATE Chinese_PRC_CI_AS NULL ,[SubmitTime] datetime2(7) NULL ,CONSTRAINT [PK__{0}__3214EC07A8A77954] PRIMARY KEY ([Id]))", tableName);
            }
            else
            {
                sql = string.Format("CREATE TABLE `{0}` (`Id` int(11) NOT NULL AUTO_INCREMENT,`TableId` int(11) DEFAULT NULL,`EnTableName` varchar(255) DEFAULT NULL,`CnTableName` varchar(255) DEFAULT NULL,`Field` varchar(255) DEFAULT NULL,`Type` varchar(255) DEFAULT NULL,`Name` varchar(255) DEFAULT NULL,`Remark` varchar(255) DEFAULT NULL,`CreateTime` datetime DEFAULT NULL,`ReviseTime` datetime DEFAULT NULL,`IsPass` int(255) DEFAULT '0',`IsDelete` int(255) DEFAULT NULL,`AuditorId` int(255) DEFAULT NULL,`AuditorName` varchar(255) DEFAULT NULL,`AuditorIp` varchar(255) DEFAULT NULL,`AuditorMac` varchar(255) DEFAULT NULL,`PassTime` datetime DEFAULT NULL,`SubmitterId` int(255) DEFAULT NULL,`SubmitterName` varchar(255) DEFAULT NULL,`SubmitterIp` varchar(255) DEFAULT NULL,`SubmitterMac` varchar(255) DEFAULT NULL,`SubmitTime` datetime DEFAULT NULL,PRIMARY KEY (`Id`)) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=gbk;", tableName);
                //  sql = string.Format("CREATE TABLE `{0}` (`Id` int(11) NOT NULL AUTO_INCREMENT,`TableId` int(11) DEFAULT NULL,`EnTableName` varchar(255) DEFAULT NULL,`CnTableName` varchar(255) DEFAULT NULL,`Field` varchar(255) DEFAULT NULL,`Type` varchar(255) DEFAULT NULL,`Name` varchar(255) DEFAULT NULL,`Remark` varchar(255) DEFAULT NULL,`IsDelete` varchar(255) DEFAULT NULL,`CreateTime` datetime DEFAULT NULL,`ReviseTime` datetime DEFAULT NULL,PRIMARY KEY(`Id`)) ENGINE = MyISAM AUTO_INCREMENT = 3771 DEFAULT CHARSET = gbk;", tableName);
            }
            return hwdal.SQL(sql);
        }

        /// <summary>
        /// 获取表中所有的数据
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAll()
        {
            return hwdal.SelectAll();
        }

        /// <summary>
        /// 获取表中部分的数据
        /// </summary>
        /// <returns></returns>
        public DataTable SelectPart(int page, int pagesize)
        {
            return hwdal.SelectPart(page, pagesize);
        }

        /// <summary>
        /// 获取表中部分的数据
        /// </summary>
        /// <returns></returns>
        public DataTable SelectSingle(string tablename)
        {
            return hwdal.SelectSingle(tablename);
        }

        /// <summary>
        /// 向表中插入数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public int? Insert(Hwdbapi table)
        {
            return hwdal.Insert(table);
        }
        /// <summary>
        /// 获取表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetTableType(string tableName)
        {
            return hwdal.GetTableType(tableName);
        }
        /// <summary>
        /// 找到最大的表id
        /// </summary>
        /// <returns></returns>
        public DataTable FindMaxId()
        {
            return hwdal.FindMaxBytid();
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="hw"></param>
        /// <returns></returns>
        public int? UpDate(Hwdbapi hw)
        {
            return hwdal.UpDate(hw);
        }

        /// <summary>
        /// 设置删除标记
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int? SetDel(string tableName)
        {
            return hwdal.SetDel(tableName);
        }

        /// <summary>
        /// 获取表的tid
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable SelectBytid(string tableName)
        {
            return hwdal.SelectBytid(tableName);
        }

    }
}
