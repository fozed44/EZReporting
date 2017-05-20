using System.Linq;
using EZDataFramework.Framework;
using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tEZReporting.tControllers {

    [TestClass]
    public class tColumnDataController {

        private static string _tReportName = "__ColumnDataControllerTest";

        [ClassInitialize]
        public static void tInitialize(TestContext c) {
            DeleteTestReport();
            CreateTestReport();
        }

        [ClassCleanup]
        public static void tCleanup() {
            DeleteTestReport();
        }       

        [TestMethod]
        public void tGetColumnData() {
            var report = ReportDataController.Get(_tReportName);
            var test  = ColumnDataController.GetColumns(report);
            Assert.IsNotNull(test);
            Assert.IsTrue(test.Count() > 1);
        }

        private static void CreateTestReport() {
            ReportDataController.Create(new Report {
                ReportName   = _tReportName,
                DatabaseName = "OnlineRisk",
                SchemaName   = "dbo",
                ProcName     = "RiskReport",
                Renderer     = "Default"
            });
        }

        private static void DeleteTestReport() {
            ReportDataController.Delete(_tReportName);
        }
    }
}
