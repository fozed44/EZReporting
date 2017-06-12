using System;
using EZDataFramework.Framework;
using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tEZReporting.Helpers;

namespace tEZReporting.tControllers {
    [TestClass]
    public class tReportDataController {

        #region Fields

        Report _testReport;

        #endregion

        [ClassInitialize]
        public static void tInitialize(TestContext c) {
            using(var disposerToken = new DataControllerBase.DisposerToken()) {
                ReportDataController.Delete(TestMetadata.ReportName);
                DataControllerBase.SaveChanges();
            }
        }

        [TestMethod]
        public void tExits_FailA() {
            using(var disposerToken = new DataControllerBase.DisposerToken()) {
                var result = ReportDataController.Exists(TestMetadata.ReportName);
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void tCreate() {
            bool result = false;
            TestReportCreator.CreateTestReport();
            try {
                using(var disposerToken = new DataControllerBase.DisposerToken()) {
                    result = ReportDataController.Exists(TestMetadata.ReportName);
                }
            } finally {
                TestReportCreator.DeleteTestReport();
            }
            Assert.IsTrue(result);
        }
        
    }
}
