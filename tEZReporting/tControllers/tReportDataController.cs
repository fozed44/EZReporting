using System;
using EZDataFramework.Framework;
using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tEZReporting.Helpers;

namespace tEZReporting.tControllers {
    [TestClass]
    public class tReportDataController {

        [ClassInitialize]
        public static void tInitialize(TestContext c) {
            ReportDataController.Delete(TestMetadata.ReportName);
        }

        [TestMethod]
        public void tExits_FailA() {
            var result = ReportDataController.Exists(TestMetadata.ReportName);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void tCreate() {
            CreateTestReport();
            var result = ReportDataController.Exists(TestMetadata.ReportName);
            Assert.IsTrue(result);
            ReportDataController.Delete(TestMetadata.ReportName);
        }

        private void CreateTestReport() {
            var report = new Report {
                DatabaseName = TestMetadata.DatabaseName,
                SchemaName   = TestMetadata.SchemaName,
                ProcName     = TestMetadata.ProcName,
                ReportName   = TestMetadata.ReportName
            };
            ReportDataController.Create(report);
        }
    }
}
