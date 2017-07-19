using GetDBInfo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GetDBInfo
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //定义定时器
            //1000表示1秒的意思
            System.Timers.Timer myTimer = new System.Timers.Timer(1000);
            //TaskAction.SetContent 表示要调用的方法
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(TaskAction.SetContent);
            myTimer.Enabled = true;
            myTimer.AutoReset = true;

            //XML Turn JSON
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }

    }
}