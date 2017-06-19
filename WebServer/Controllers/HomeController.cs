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

            using(var dp = new DataControllerBase.DisposerToken()) {
                var reports     = ReportDataController.GetAll();
                var conStrings  = ConnectionStringDataController.GetAll();
                var tableStyles = TableStyleDataController.GetAll();
                return View(
                    new HomeModel {
                        Reports = reports,
                        ConnectionStrings = conStrings,
                        TableStyles = tableStyles
                    }
                );
            }

        }
    }
}