using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoggingOperationsAssembly;

namespace ProiectMIPFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LoggingOps.filePath = LoggingOps.CreateLogFile("Logging.txt");
            LoggingOps.filePath = "C:\\Program Files\\IIS Express\\Logging.txt";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChangeLanguage(string lang)
        {
            Session["lang"] = lang;

            return RedirectToAction("Index", "Home",
                new { language = lang });
        }
    }
}