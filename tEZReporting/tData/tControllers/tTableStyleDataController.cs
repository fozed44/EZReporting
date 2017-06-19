using System.Linq;
using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tEZReporting.Helpers;

namespace tEZReporting.tControllers {
    [TestClass]
    public class tTableStyleDataController {

        [TestMethod]
        public void tGet() {
            try {
                TestReportCreator.EnsureCreated();
                using(var disposerToken = new DataControllerBase.DisposerToken()) {
                    var testReport = ReportDataController.Get("TestReport");
                    var result = TableStyleDataController.Get(testReport.TableStyle.pkID);
                    Assert.IsNotNull(result);
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
                    var result = ConnectionStringDataController.GetAll();
                    Assert.IsNotNull(result);
                    Assert.IsTrue(result.Count() > 0);
                }
            } finally {
                TestReportCreator.EnsureRemoved();
            }
        }
    }
}
