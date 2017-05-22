using System.Linq;
using EZDataFramework.Framework;
using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tEZReporting.Helpers;

namespace tEZReporting.tControllers {

    [TestClass]
    public class tColumnDataController {        

        [ClassInitialize]
        public static void tInitialize(TestContext c) {
            DeleteTestReport();
            CreateTestReport();
        }

        [ClassCleanup]
        public static void tCleanup() {
            DeleteTestReport();
        }       

        [TestMethod]
        public void tGetColumnData() {
            var report = ReportDataController.Get(TestMetadata.ReportName);
            var test  = ColumnDataController.GetColumns(report);
            Assert.IsNotNull(test);
            Assert.IsTrue(test.Count() > 1);
        }

        #region Private

        private static void CreateTestReport() {
            ReportDataController.Create(new Report {
                ReportName   = TestMetadata.ReportName,
                DatabaseName = TestMetadata.DatabaseName,
                SchemaName   = TestMetadata.SchemaName,
                ProcName     = TestMetadata.ProcName,
                Renderer     = "Default"
            });
        }

        private static void DeleteTestReport() {
            ReportDataController.Delete(TestMetadata.ReportName);
        }

        #endregion

    }
}
