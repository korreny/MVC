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
    public class InfoController : ApiController
    {
        /// <summary>
        /// 返回请求数据 请求格式: GET: http://localhost:55039/jcservice/info?account=admin&password=admin
        /// </summary>
        /// <param name="account">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public WebApi GetInfo(string account, string password)
        {

            HwdbapiBLL hwbll = new HwdbapiBLL();
            Hwdbapi hw = new Hwdbapi();
            List<Hwdbapi> list = new List<Hwdbapi>();
            DataTable dt = hwbll.SelectAll();
            var temp = DataConvert<hwdbapiEntity>.ToList(dt);

            GetDBInfo.BLL.UserServiceBLL userMessage = new GetDBInfo.BLL.UserServiceBLL();
            GetDBInfo.Model.User user = new GetDBInfo.Model.User();
            user.Account = account;
            user.Password = password;
            userMessage.UserLogin(user);

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
        //public WebApi GetInfo(string account, string password)
        //{
        //    HwdbapiBLL hwbll = new HwdbapiBLL();
        //    Hwdbapi hw = new Hwdbapi();
        //    List<Hwdbapi> list = new List<Hwdbapi>();
        //    DataTable dt = hwbll.SelectAll();
        //    var temp = DataConvert<hwdbapiEntity>.ToList(dt);

        //    GetDBInfo.BLL.UserServiceBLL userMessage = new GetDBInfo.BLL.UserServiceBLL();
        //    GetDBInfo.Model.User user = new GetDBInfo.Model.User();
        //    user.Account = account;
        //    user.Password = password;
        //    userMessage.UserLogin(user);

        //    //foreach (var t in temp)
        //    //{
        //    //    hw = t;
        //    //    list.Add(hw);
        //    //}

        //    List<object> objList = new List<object>();
        //    foreach (DataRow r in dt.Rows)
        //    {
        //        objList.Add(r.ItemArray);
        //        // t = r.ItemArray;
        //    }
        //    WebApi _webApi = new WebApi
        //    {
        //        Code = 1,
        //        Msg = "Request Success!",
        //        Data = objList
        //    };

        //    return _webApi;
        //}
    }
}
