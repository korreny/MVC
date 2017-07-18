using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GetDBInfo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "jcservice/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
