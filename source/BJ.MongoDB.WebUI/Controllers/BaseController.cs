using System;
using System.Text;
using System.Web.Mvc;

namespace BJ.MongoDB.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public virtual ActionResult Back(string addUrl)                                                                 
        {
            string returnUrl = Request.QueryString["ReturnUrl"] ?? Request.Form["ReturnUrl"];
            if (!string.IsNullOrEmpty(returnUrl))
            {
                if (returnUrl.Contains("?"))
                {
                    string args = returnUrl.Substring(returnUrl.IndexOf("?", StringComparison.Ordinal) + 1);
                    string[] aargs = args.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                    var sb = new StringBuilder();
                    foreach (string a in aargs)
                    {
                        if (sb.Length > 0)
                            sb.Append("&");
                        string s = a;
                        if (a.Contains("="))
                            s = s.Remove(s.IndexOf("=", StringComparison.Ordinal)) + "=";
                        if (!addUrl.Contains(s))
                            sb.Append(a);
                    }
                    returnUrl = returnUrl.Remove(returnUrl.IndexOf("?", StringComparison.Ordinal)) + "?" + sb.ToString();
                }

                if (!string.IsNullOrEmpty(addUrl))
                    returnUrl += (returnUrl.Contains("?") ? "&" : "?") + addUrl;
            }
            if (!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction("Index", "Home");
        }

        //----------------------------------------------------------------------------------------

        public virtual ActionResult Back()
        {
            return Back(string.Empty);
        }

        //----------------------------------------------------------------------------------------

        protected ActionResult NotAuthorizedResult(string message = null)
        {
            return ErrorView(message ?? "Доступ запрещен");
        }

        //----------------------------------------------------------------------------------------

        protected ActionResult NotFoundResult(string message = null)
        {
            return ErrorView(message ?? "Страница не найдена");
        }

        //----------------------------------------------------------------------------------------

        protected ActionResult ErrorView(string message)
        {
            ViewBag.Error = message;
            return View("~/Views/Shared/Error.cshtml");
        }

        //----------------------------------------------------------------------------------------


    }
}