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
            return View("DBAPI");
        }
    }
}
