using System;
using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tEZReporting.tControllers {
    [TestClass]
    public class tReportDataController {

        private string _testReportName = "TestReport";
        private string _testDatabaseName = "TestDatabase";
        private string _testSchemaName = "TestSchema";
        private string _testProcName = "TestProc";

        [TestInitialize]
        public void tInitialize() {
            ReportDataController.Delete(_testReportName);
        }


        [TestMethod]
        public void tExits_FailA() {
            var result = ReportDataController.Exists(_testReportName);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void tExists_FailB() {
            var result = ReportDataController.Exists(_testDatabaseName, _testSchemaName, _testProcName);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void tCreate() {
            var report = new Report {
                DatabaseName = _testDatabaseName,
                SchemaName   = _testSchemaName,
                ProcName     = _testProcName,
                ReportName   = _testReportName
            };
            ReportDataController.Create(report);

            var result = ReportDataController.Exists(_testReportName);
            Assert.IsTrue(result);
        }
    }
}
