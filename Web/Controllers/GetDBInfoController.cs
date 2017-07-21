using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GetDBInfo.Model;
using GetDBInfo.BLL;
using System.Data;
using GetDBInfo.DataMap.ORM;
using GetDBInfo.DataMap.ORM.Entity;
using GetDBInfo.Models;

namespace GetDBInfo.Controllers
{
    public class GetDBInfoController : ApiController
    {
        /// <summary>
        /// 返回请求数据 请求格式: GET: 
        /// 
        /// 
        /// 获取 某张表的 的信息
        /// http://localhost:55039/jcservice/getdbinfo?tablename
        /// 
        /// 
        /// 
        /// 获取 第page张表 至 第pagesize张表 的所有信息
        /// http://localhost:55039/jcservice/getdbinfo?tablename=&page=1&pagesize=2
        /// 
        /// 
        /// 获取 所有表 的信息
        /// http://localhost:55039/jcservice/getdbinfo
        /// 
        /// </summary>
        /// <returns></returns>


        //GET api/User/?username=xx
        public WebApi GetInfoByTableName(string tablename, int page, int pagesize)
        {
            //获取数据库中表的数据
            HwdbapiBLL hwbll = new HwdbapiBLL();
            Hwdbapi hw = new Hwdbapi();
            List<Hwdbapi> list = new List<Hwdbapi>();
            DataTable dt = new DataTable();
            List<Models.GetInfo> infoResList = new List<Models.GetInfo>();
            // 处理过滤条件
            if (tablename == null && page == 0 && pagesize == 0)
            {
                // 获取表中所有表的数据
                dt = hwbll.SelectAll();
            }
            else if (tablename == null)
            {
                //获取表中部分表的数据
                dt = hwbll.SelectPart(page, pagesize);
            }
            else
            {
                //获取表中单个表的数据
                dt = hwbll.SelectSingle(tablename);
            }
            var temp = DataConvert<hwdbapiEntity>.ToList(dt);
            #region 对表做处理
            try
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    Models.GetInfo tt = new Models.GetInfo();
                    if (tt.TableName != temp[i].EnTableName)
                    {
                        try
                        {
                            List<Fieid> fieidlist = new List<Fieid>();
                            tt.TableName = temp[i].EnTableName;
                            for (; tt.TableName == temp[i].EnTableName; i++)
                            {
                                Fieid fieid = new Fieid();
                                fieid.Fieidname = temp[i].Field;
                                fieid.Fieidtype = temp[i].Type;
                                fieid.Fieidmean = "暂时未设置";
                                fieidlist.Add(fieid);
                            }
                            tt.Field = fieidlist;
                            infoResList.Add(tt);
                        }
                        catch (System.ArgumentOutOfRangeException e)
                        {
                            //下标越界,表示当前表结束
                            break;
                        }
                    }
                }
            }catch(System.NullReferenceException e)
            {
                //数据为空
                infoResList = null;
                //return 
            }

            #endregion
            WebApi _webApi = new WebApi
            {
                Code = 1,
                Msg = "Request Success!",
                Data = infoResList
            };
            return _webApi;
        }
    }
}
