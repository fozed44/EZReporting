using System.Web.Mvc;
using EZReporting.Data;
using EZReporting.Interface;
using EZReporting.Location;
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
            var reportMetaData = ReportDataController.Get(reportName);

            result.Report = reportMetaData;
            result.Parameters          = ParameterDataController.GetParameters(reportMetaData);
            result.OutputColumns       = ColumnDataController.GetColumns(reportMetaData);
            result.ParameterConverters = ImplementationEnumerator.Locate(typeof(IConverter));
            result.OutputConverters    = ImplementationEnumerator.Locate(typeof(IConverter));
            result.Formatters          = ImplementationEnumerator.Locate(typeof(IFormatter));

            return result;
        }

        #endregion
    }
}