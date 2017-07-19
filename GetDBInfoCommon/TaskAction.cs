using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using com.iflysse.helper;
using GetDBInfo.Model;
using GetDBInfo.BLL;

namespace GetDBInfo.Common
{
    public static class TaskAction
    {

        static string StratTime = ConfigurationManager.AppSettings["StartTime"];
        private static string content = "";
        /// <summary>
        /// 输出信息存储的地方.
        /// </summary>
        public static string Content
        {
            get { return TaskAction.content; }
            set { TaskAction.content += "<div>" + value + "</div>"; }
        }
        /// <summary>
        /// 应用池回收的时候调用的方法
        /// </summary>
        public static void SetContent()
        {
            Content = "END: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 定时器委托任务 调用的方法
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public static void SetContent(object source, System.Timers.ElapsedEventArgs e)
        {

            if (DateTime.Now.ToString("HH:mm:ss") == StratTime)
            {

                //记录表中最大的tid
                int maxtid = 0;

                Hwdbapi hwdbapi = new Hwdbapi();
                DBinfo dbinfo = new DBinfo(Convert.ToInt32(ConfigurationManager.AppSettings["DBtype"]), ConfigurationManager.AppSettings["DBIp"], ConfigurationManager.AppSettings["DBUid"], ConfigurationManager.AppSettings["DBPwd"], ConfigurationManager.AppSettings["DBname"]);//存放数据信息
                DBInfoBLL.dbinfo = dbinfo;
                DBInfoBLL dbbll = new DBInfoBLL(dbinfo);
                HwdbapiBLL hwbll = new HwdbapiBLL();

                //判断表的状态
                DataTable dt = hwbll.GetTableType(ConfigurationManager.AppSettings["ResultTableName"]);

                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string tName = dt.Rows[i][0].ToString();
                        if (dt.Rows.Count == 22 && (tName == "Id" || tName == "TableId" || tName == "EnTableName" || tName == "CnTableName" || tName == "Field" || tName == "Type" || tName == "Name" || tName == "Remark" || tName == "IsDelete" || tName == "CreateTime" || tName == "ReviseTime" || tName == "AuditorName" || tName == "IsPass"
                            || tName == "AuditorId" || tName == "AuditorIp" || tName == "AuditorMac" || tName == "PassTime" || tName == "SubmitterId" || tName == "SubmitterName" || tName == "SubmitterIp" || tName == "SubmitterMac" || tName == "SubmitTime"
                            ))
                        {

                        }
                        else
                        {
                            //创建表
                            // 1修改配置文件
                            AppConfigHelper.ModifyAppSettings("ResultTableName", ConfigurationManager.AppSettings["ResultTableName"] + "_bak");
                            hwbll.CreateTable(ConfigurationManager.AppSettings["ResultTableName"]);
                            break;
                        }
                    }
                }
                catch (System.NullReferenceException ex)
                {
                    hwbll.CreateTable(ConfigurationManager.AppSettings["ResultTableName"]);
                }
                try
                {
                    if (dt.Rows.Count == 0)
                    {
                        hwbll.CreateTable(ConfigurationManager.AppSettings["ResultTableName"]);
                    }
                }
                catch (System.NullReferenceException ex)
                {
                }
                try
                {
                    //寻找表中最大是ID号
                    maxtid = Convert.ToInt32(hwbll.FindMaxId().Rows[0][0].ToString());
                }
                catch (Exception ex)
                {
                    maxtid = 0;
                }

                DataTable tables = dbbll.GetTables();//获取表的集合

                if (tables == null)
                {
                    //数据库不存在
                    return;
                }
                for (int i = 0; i < tables.Rows.Count; i++)
                {

                    hwbll.SetDel(tables.Rows[i][2].ToString());

                    //判断是否有格式如:tablename11,tablename12的表名
                    string tableName = tables.Rows[i][2].ToString();
                    string s = "^\\D+\\d{1,2}$";
                    //;
                    if (Regex.IsMatch(tableName, s))
                    {
                        for (int k = 0; k < tables.Rows.Count; k++)
                        {
                            if ((tables.Rows[i][2].ToString().IndexOf(tables.Rows[k][2].ToString()) == 0 && k != i))
                            {
                                //有的话则处理一下
                                tables.Rows.RemoveAt(i);
                                break;
                            }
                        }
                        continue;
                        //  break;
                    }
                    int tid = ++maxtid;

                    DataTable tableType = dbbll.GetTableType(tables.Rows[i][2].ToString());
                    //遍历表
                    for (int j = 0; j < tableType.Rows.Count; j++)
                    {
                        hwdbapi.EnTableName = tables.Rows[i][2].ToString();
                        hwdbapi.Field = tableType.Rows[j][0].ToString();
                        hwdbapi.Type = tableType.Rows[j][1].ToString();
                        hwdbapi.Tableid = tid;
                        hwdbapi.ReviseTime = null;
                        hwdbapi.IsDelete = 0;
                        int? res = hwbll.UpDate(hwdbapi);
                        if (res == 0 || res == null)
                        {
                            //获取当前表的id
                            try
                            {
                                hwdbapi.Tableid = Convert.ToInt32(hwbll.SelectBytid(tables.Rows[i][2].ToString()).Rows[0][0].ToString());
                            }
                            catch (Exception ex)
                            {
                                //当获取出错的时候,就是数据库中没有的表
                            }
                            hwdbapi.CreateTime = DateTime.Now;
                            hwbll.Insert(hwdbapi);
                        }
                    }
                    try
                    {
                        //处理完成
                    }
                    catch (Exception ex)
                    {
                        break;
                        //在datetable用已经删除
                        //直接忽略
                    }
                }
            }

        }   

     
    } 
}
