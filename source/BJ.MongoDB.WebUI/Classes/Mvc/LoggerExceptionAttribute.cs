using System.Web.Mvc;

using BJ.MongoDB.Logger;


namespace BJ.MongoDB.WebUI
{
    public class LoggerExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && (
                filterContext.Exception is LoggerConnectionException
             || filterContext.Exception is LoggerReadException
             || filterContext.Exception is LoggerWriteException
             || filterContext.Exception is LoggerDeleteException))
            {
                filterContext.Result = new RedirectResult("~/Views/Shared/Error.cshtml");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}