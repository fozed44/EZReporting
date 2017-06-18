using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using EZDataFramework.Framework;
using EZReporting.Data;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(){
            IEnumerable<Report> reports;

            using(var dp = new DataControllerBase.DisposerToken())
                reports = ReportDataController.GetAll();

            return View(new HomeModel { Reports = reports });
        }
    }
}