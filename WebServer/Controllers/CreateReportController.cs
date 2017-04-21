using System;
using System.Web.Mvc;
using EZReporting.Data;
using EZReporting.Enumeration;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class CreateReportController : Controller
    {
        #region PAGE

        // GET: CreateReport
        public ActionResult Index(){
            return View(new CreateViewModel {
                Databases = SqlEnumerator.EnumerateDatabases()
            });
        }

        #endregion

        #region AJAX

        [HttpGet]
        public JsonResult GetProcedures(string database, string schema) {
            return new JsonResult {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new {                    
                    procs = SqlEnumerator.EnumerateStoredProcs(database, schema)
                }
            };
        }

        [HttpGet]
        public JsonResult GetSchemas(string database) {
            return new JsonResult {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new {
                    schemas = SqlEnumerator.EnumerateSchemas(database)
                }
            };
        }

        [HttpPost]
        public JsonResult CreateReport(string reportName, string database, string schema, string procedure) {

            try {
                EZReporting.Data.ReportDataController.Create(new Report {
                    ReportName   = reportName,
                    DatabaseName = database,
                    SchemaName   = schema,
                    ProcName     = procedure
                });
            } catch (Exception e) {
                return new JsonResult {
                    Data = new {
                        success = false,
                        errorMessage = e.Message
                    }
                };
            }

            return new JsonResult {
                Data = new {
                    success = true
                }
            };
        }

        #endregion

    }
}