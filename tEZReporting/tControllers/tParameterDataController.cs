using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace tEZReporting.tControllers {

    [TestClass]
    public class tParameterDataController {

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
        public void tGetParameters() {
            var report = ReportDataController.Get(_tReportName);
            var test = ParameterDataController.GetParameters(report);
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
