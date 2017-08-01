using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EZDataFramework.Framework;
using EZReporting.Data;
using WebServer.Models;

namespace WebServer.Controllers
{
    [RoutePrefix("ConnectionString")]
    [Route("{action=index}")]
    public class ConnectionStringController : Controller {

        #region Page

        public ActionResult Index() {
            using(var dp = new DataControllerBase.DisposerToken()) {
                return View(new ConnectionStringViewModel { ConnectionStrings = ConnectionStringDataController.GetAll() });
            }
        }

        #endregion

        #region Ajax

        [HttpGet]
        public JsonResult GetConnectionStrings() {
            using(var dp = new DataControllerBase.DisposerToken()) {
                return Json(ConnectionStringDataController.GetAll());
            }
        }

        [HttpPut]
        public void AddConnectionString([Required] string name, [Required] string value) {
            using(var dp = new DataControllerBase.DisposerToken()) {
                ConnectionStringDataController.AddConnectionString(
                    new ConnectionString {
                        Name  = name,
                        Value = value
                    }
                );
            }
        }

        [HttpPost]
        public void EditConnectionString([Required] int pkID, [Required] string name, [Required] string value) {
            using(var dp = new DataControllerBase.DisposerToken()) {
                var connectionString = ConnectionStringDataController.Get(pkID);

                if(connectionString == null) return;

                connectionString.Name  = name;
                connectionString.Value = value;
                ConnectionStringDataController.SaveChanges();
            }
        }

        [HttpPost]
        public void DeleteConnectionString([Required] int pkID) {
            using(var dp = new DataControllerBase.DisposerToken()) {
                var connectionString = ConnectionStringDataController.Get(pkID);

                if(connectionString == null) return;

                ConnectionStringDataController.DeleteConnectionString(connectionString);
                ConnectionStringDataController.SaveChanges();
            }
        }

        #endregion

    }
}