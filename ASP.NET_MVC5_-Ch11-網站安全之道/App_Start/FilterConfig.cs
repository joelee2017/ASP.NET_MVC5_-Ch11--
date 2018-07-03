using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC5__Ch11_網站安全之道
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
