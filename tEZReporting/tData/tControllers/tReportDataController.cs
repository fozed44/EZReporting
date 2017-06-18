using System;
using EZDataFramework.Framework;
using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tEZReporting.Helpers;

namespace tEZReporting.tControllers {
    [TestClass]
    public class tReportDataController {

        [TestMethod]
        public void tExits_FailA() {
            TestReportCreator.EnsureRemoved();
            using(var disposerToken = new DataControllerBase.DisposerToken()) {
                var result = ReportDataController.Exists(TestMetadata.ReportName);
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void tCreate() {
            bool result = false;
            TestReportCreator.EnsureCreated();
            try {
                using(var disposerToken = new DataControllerBase.DisposerToken()) {
                    result = ReportDataController.Exists(TestMetadata.ReportName);
                }
            } finally {
                TestReportCreator.EnsureRemoved();

            }
            Assert.IsTrue(result);
        }
        
    }
}
