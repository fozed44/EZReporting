using System;
using System.Linq;
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
            try {
                TestReportCreator.EnsureCreated();
                using(var disposerToken = new DataControllerBase.DisposerToken()) {
                    var result = ReportDataController.Exists(TestMetadata.ReportName);
                    Assert.IsTrue(result);
                }
            } finally {
                TestReportCreator.EnsureRemoved();
            }
        }

        [TestMethod]
        public void tGetAll() {
            try {
                TestReportCreator.EnsureCreated();
                using(var dp = new DataControllerBase.DisposerToken()) {
                    var result = ReportDataController.GetAll();
                    Assert.IsNotNull(result);
                    Assert.IsTrue(result.Count() > 0);
                }
            } finally {
                TestReportCreator.EnsureRemoved();
            }
        }
        
    }
}
