using System.Linq;
using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tEZReporting.tControllers {

    [TestClass]
    public class tColumnDataController {

        private string _tReportName = "__ColumnDataControllerTest";

        [ClassInitialize]
        public void tInitialize() {
            DeleteTestReport();
            CreateTestReport();
        }

        [ClassCleanup]
        public void tCleanup() {

        }       

        [TestMethod]
        public void tGetColumnData() {
            var report = ReportDataController.Get(_tReportName);
            var test  = ColumnDataController.GetColumns(report);
            Assert.IsNotNull(test);
            Assert.IsTrue(test.Count() > 1);
        }

        private void CreateTestReport() {
            ReportDataController.Create(new Report {
                ReportName   = _tReportName,
                DatabaseName = "OnlineRisk",
                SchemaName   = "dbo",
                ProcName     = "RiskReports",
                Renderer     = "Default"
            });
        }

        private void DeleteTestReport() {
            ReportDataController.Delete(_tReportName);
        }
    }
}
