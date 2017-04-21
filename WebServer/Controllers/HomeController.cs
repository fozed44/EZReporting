using System.Web.Mvc;
using EZReporting.Data;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(){
            return View(new HomeModel {
                Reports = ReportDataController.GetAll()
            });
        }
    }
}