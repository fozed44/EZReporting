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
                return Json(new {
                    success = true,
                    connectionStrings = ConnectionStringDataController.GetAll()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Create([Required] string Name, [Required] string Value) {
            if(string.IsNullOrEmpty(Name))
                return Json(new {
                    success = false,
                    message = $"{nameof(Name)} is a required parameter."
                });
            if(string.IsNullOrEmpty(Value))
                return Json(new {
                    success = false,
                    message = $"{nameof(Value)} is a required parameter."
                });

            using(var dp = new DataControllerBase.DisposerToken()) {
                ConnectionStringDataController.AddConnectionString(
                    new ConnectionString {
                        Name  = Name,
                        Value = Value
                    }
                );
            }

            return Json(new {
                success = true
            });
        }

        [HttpPost]
        public JsonResult Update([Required] int pkID, [Required] string name, [Required] string value) {
            using(var dp = new DataControllerBase.DisposerToken()) {
                var connectionString = ConnectionStringDataController.Get(pkID);

                if(connectionString == null)
                    return Json(new {
                        success = false,
                        message = $"Could not find connection string '{name}'"
                    });

                connectionString.Name  = name;
                connectionString.Value = value;
                ConnectionStringDataController.SaveChanges();
            }
            return Json(new {
                success = true
            });
        }

        [HttpPost]
        public JsonResult Delete([Required] int pkID) {
            using(var dp = new DataControllerBase.DisposerToken()) {
                var connectionString = ConnectionStringDataController.Get(pkID);

                if(connectionString == null)
                    return Json(new {
                        success = false,
                        message = $"Could not find connection string '{pkID}'"
                    });

                ConnectionStringDataController.DeleteConnectionString(connectionString);
                ConnectionStringDataController.SaveChanges();
            }
            return Json(new {
                success = true
            });
        }

        #endregion

    }
}