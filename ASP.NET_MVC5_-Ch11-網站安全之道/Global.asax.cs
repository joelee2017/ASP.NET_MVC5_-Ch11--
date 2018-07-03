using ASP.NET_MVC5__Ch11_網站安全之道.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ASP.NET_MVC5__Ch11_網站安全之道
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //修改預設防偽 CookieName
            AntiForgeryConfig.CookieName = "Mvc180703";
            AntiForgeryConfig.AdditionalDataProvider = new AntiForgeryExtension();

        }
    }
}
