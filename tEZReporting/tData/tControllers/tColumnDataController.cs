using System.Linq;
using EZDataFramework.Framework;
using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tEZReporting.Helpers;

namespace tEZReporting.tControllers {

    [TestClass]
    public class tColumnDataController {     

        [TestMethod]
        public void tGetColumnData() {
            try {
                TestReportCreator.CreateTestReport();
                using(var disposerToken = new DataControllerBase.DisposerToken()) {
                    var report = ReportDataController.Get(TestMetadata.ReportName);
                    var test = ColumnDataController.GetColumns(report);
                    Assert.IsNotNull(test);
                    Assert.IsTrue(test.Count() > 1);
                }
            } finally {
                TestReportCreator.DeleteTestReport();
            }
        }
        
    }
}
