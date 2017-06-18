using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using EZDataFramework.Framework;
using tEZReporting.Helpers;

namespace tEZReporting.tControllers {

    [TestClass]
    public class tParameterDataController {

        [TestMethod]
        public void tGetParameters() {
            try {
                TestReportCreator.EnsureCreated();
                using(var desposerToken = new DataControllerBase.DisposerToken()) {
                    var report = ReportDataController.Get(TestMetadata.ReportName);
                    var test = ParameterDataController.GetParameters(report);
                    Assert.IsNotNull(test);
                    Assert.IsTrue(test.Count() > 0);
                }
            } finally {
                TestReportCreator.EnsureRemoved();
            }
        }

        /// <summary>
        /// Test the ParameterDataController.GetParameters() method, make sure that the parameter
        /// objects returned from the controller have all required properties populated.
        /// </summary>
        [TestMethod]
        public void tCheckRetrievedParameter() {
            try {
                TestReportCreator.EnsureCreated();
                using(var disposerToken = new DataControllerBase.DisposerToken()) {
                    var report = ReportDataController.Get(TestMetadata.ReportName);
                    var test   = ParameterDataController.GetParameters(report);
                    Assert.IsNotNull(test);
                    Assert.IsTrue(test.Count() > 0);

                    foreach(var param in test) {
                        Assert.IsTrue(!string.IsNullOrEmpty(param.DBType));
                        Assert.IsTrue(!string.IsNullOrEmpty(param.ParameterName));
                    }
                }
            } finally {
                TestReportCreator.EnsureRemoved();
            }
        }

    }
}
