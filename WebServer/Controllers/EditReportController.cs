using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class EditReportController : Controller
    {
        #region PAGE

        // GET: EditReport
        public ActionResult Index(string reportName){
            if(string.IsNullOrEmpty(reportName))
                return RedirectToAction(
                    "Error",
                    "EditReport",
                    new { message = $"A report name was not supplied." }
                );

            var model = GetEditModel(reportName);
            if(model == null)
                return RedirectToAction(
                    "Error", 
                    "EditReport", 
                    new { message = $"Can't find data for report {reportName}." }
                );
            return View(model);
        }

        // GET: Error
        public ActionResult Error(string message) {
            return View((object)message);
        }

        #endregion

        #region AJAX

        #endregion

        #region Helpers

        private EditModel GetEditModel(string reportName) {
            var result = new EditModel();
            var reportMetaData = EZReporting.Data.ReportDataController.Get(reportName);

            result.ReportName = reportMetaData.ReportName;
            result.Parameters = EZReporting.Default.DefaultsGenerator.GenerateDefaultParameters(reportMetaData.ReportName);
            result.OutputColumns = EZReporting.Default.DefaultsGenerator.GenerateDefaultOutputColumns(reportMetaData.ReportName);

            return result;
        }

        #endregion
    }
}