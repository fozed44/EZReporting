using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using EZDataFramework.Framework;
using tEZReporting.Helpers;

namespace tEZReporting.tControllers {

    [TestClass]
    public class tParameterDataController {
        
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
        public void tGetParameters() {
            var report = ReportDataController.Get(TestMetadata.ReportName);
            var test = ParameterDataController.GetParameters(report);
            Assert.IsNotNull(test);
            Assert.IsTrue(test.Count() > 1);
        }

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

    }
}
