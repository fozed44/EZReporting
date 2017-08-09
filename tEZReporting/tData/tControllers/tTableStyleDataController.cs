using System.Linq;
using EZDataFramework.Framework;
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

        [TestMethod]
        public void tAddDelete() {

            // CREATE
            TableStyle newTableStyle;
            using(var dp = new DataControllerBase.DisposerToken()) {
                newTableStyle = TableStyleDataController.AddTableStyle(new TableStyle {
                    Name           = "UnitTestName",
                    CellStyle      = "UnitTestCellStyle",
                    EvenRowStyle   = "UnitTestRowStyle",
                    HeaderRowStyle = "UnitTestHeaderRowStyle",
                    HeaderStyle    = "UnitTestHeaderStyle",
                    OddRowStyle    = "UnitTestOddRowStyle",
                    RowStyle       = "UnitTestRowStyle",
                    Style          = "UnitTestStyle"
                });
            }

            Assert.IsNotNull(newTableStyle, "Failed to create table style.");
            Assert.IsTrue(newTableStyle.pkID > 0, "Failed to get a new ID from the new table style.");

            // DELETE
            using(var dp = new DataControllerBase.DisposerToken()) {
                TableStyleDataController.DeleteTableStyle(newTableStyle);
            }

            // ENSURE DELETETION
            using(var dp = new DataControllerBase.DisposerToken()) {
                var result = TableStyleDataController.Get(newTableStyle.pkID);
                Assert.IsNull(result);
            }
        }
    }
}
