using System.Web;
using System.Web.Mvc;

namespace BJ.MongoDB.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoggerExceptionAttribute());
            filters.Add(new NoCacheFilter());
        }
    }
}