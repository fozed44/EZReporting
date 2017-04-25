using System;
using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tEZReporting.tControllers {
    [TestClass]
    public class tReportDataController {

        private const string _testReportName   = "TestReport";
        private const string _testDatabaseName = "OnlineRisk";
        private const string _testSchemaName   = "dbo";
        private const string _testProcName     = "RiskReport";

        [ClassInitialize]
        public static void tInitialize(TestContext c) {
            ReportDataController.Delete(_testReportName);
        }

        [TestMethod]
        public void tExits_FailA() {
            var result = ReportDataController.Exists(_testReportName);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void tCreate() {
            CreateTestReport();
            var result = ReportDataController.Exists(_testReportName);
            Assert.IsTrue(result);
            ReportDataController.Delete(_testReportName);
        }

        private void CreateTestReport() {
            var report = new Report {
                DatabaseName = _testDatabaseName,
                SchemaName   = _testSchemaName,
                ProcName     = _testProcName,
                ReportName   = _testReportName
            };
            ReportDataController.Create(report);
        }
    }
}
