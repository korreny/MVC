using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetDBInfo;
using GetDBInfo.Model;
using GetDBInfo.BLL;
using System.Data;
using GetDBInfo.DataMap.ORM;
using GetDBInfo.DataMap.ORM.Entity;

namespace GetDBInfo.Controllers
{
    public class DocController : Controller
    {
        // GET: /Doc/
        public ActionResult Index()
        {
            //HwdbapiBLL hwbll = new HwdbapiBLL();
            //Hwdbapi hw = new Hwdbapi();
            //List<Hwdbapi> list = new List<Hwdbapi>();
            //DataTable dt = new DataTable();
            //List<Models.GetInfo> infoResList = new List<Models.GetInfo>();
            //var temp = DataConvert<hwdbapiEntity>.ToList(dt);

            return View("DBAPI");
        }
    }
}
