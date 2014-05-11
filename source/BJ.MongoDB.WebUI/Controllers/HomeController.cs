using System;
using System.Linq;
using System.Web.Mvc;

using BJ.MongoDB.Logger;

using BJ.MongoDB.WebUI.Classes;
using BJ.MongoDB.WebUI.Models;

namespace BJ.MongoDB.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogService logService;

        //----------------------------------------------------------------------------------------

        public HomeController(ILogService logService)
        {
            if (logService == null)
                throw new ArgumentNullException("logService");

            this.logService = logService;
        }

        //----------------------------------------------------------------------------------------

        public ActionResult Index()
        {
            var appsName = logService.GetAppsNameWithCount();

            ViewBag.TotalCount = logService.CountLogs();

            return View(appsName);
        }

        //----------------------------------------------------------------------------------------
        
        public ActionResult Logs(LogViewFilters filters)
        {
            ViewBag.AppsName = new SelectList(logService.GetAppsName().AsEnumerable());

            LogViewModel result = logService.GetLogs(filters);

            return View(result); 
        }

        //----------------------------------------------------------------------------------------

        public ActionResult Details(string id)
        {
            LogItem Log = logService.Find(id);

            if (Log != null)
            {
                var result = new LogItemViewModel(Log);
                return View(result);
            }

            string strError = String.Format("Сообщение журнала с идентификатором \"{0}\" не найдено", id);
            return NotFoundResult(strError);
        }

        //----------------------------------------------------------------------------------------

        public ActionResult Stat(string app)
        {
            var result = new StatViewModel
            {
                AppsName = new SelectList(logService.GetAppsName().AsEnumerable()),
                StatLevel = logService.GetStatLevel(),
                StatApp = String.IsNullOrWhiteSpace(app) ? new StatAppItem() : logService.GetStatApp(app),
                StatOS = logService.GetStatOS()
            };

            return View(result);
        }

        //----------------------------------------------------------------------------------------

        public ActionResult About()
        {
            ViewBag.AsmTitle = String.Format("{0}", AssemblyInfo.AssemblyProduct);
            ViewBag.Version = String.Format("Версия {0}", AssemblyInfo.AssemblyVersion);
            ViewBag.Copyright = AssemblyInfo.AssemblyCopyright;
            ViewBag.Company = AssemblyInfo.AssemblyCompany;

            return View();
        } 
    }
}
