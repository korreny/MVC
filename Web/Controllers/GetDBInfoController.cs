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


            foreach (var t in temp)
            {
                hw = t;
                list.Add(hw);
            }
            WebApi _webApi = new WebApi
            {
                Code = 1,
                Msg = "Request Success!",
                Data = list
            };
            return _webApi;
        }
    }
}
