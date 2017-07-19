using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetDBInfo.BLL;
using GetDBInfo;
using GetDBInfo.Model;
using com.iflysse.helper;
using System.Threading;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;

namespace GetDBInfo.Controllers        
{
    public class HomeController : Controller
    {
        // GET: /User/
        public ActionResult Index()
        {

            return View("UserLogin");
        }
     
        //User login action method
        public ActionResult UserLogin()
        {
            //【1】Receive data (encapsulate the received data as an object)
            User user = new User()
            {
                Account = Convert.ToString(Request.Params["account"]),
                Password = Convert.ToString(Request.Params["password"])
            };

            //【2】Business processing (call the background model, the realization of user information judgment)
            user = new UserServiceBLL().UserLogin(user);

            //【3】Return data (view, controller, others...) (jump)
            if (user.Nickname != null)
            {
                ViewData["info"] = "Welcome：" + user.Nickname;
                return RedirectToAction("Index", "Doc");
            }
            else
            {
                ViewData["info"] = "ERROR Incorrect username or password！";
            }
            return View("UserLogin");
        }
      
    }

}
