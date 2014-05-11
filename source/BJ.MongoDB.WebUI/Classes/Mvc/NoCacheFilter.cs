using System;
using System.Web;
using System.Web.Mvc;

namespace BJ.MongoDB.WebUI
{
    public class NoCacheFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpCachePolicy = filterContext.HttpContext.Response.Cache;
            
            httpCachePolicy.SetCacheability(HttpCacheability.NoCache);
            httpCachePolicy.SetNoStore();
            httpCachePolicy.SetExpires(new DateTime(2000, 1, 1));
        }
    }
}