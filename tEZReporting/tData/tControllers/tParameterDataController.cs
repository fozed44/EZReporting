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
            Assert.IsTrue(test.Count() > 0);
        }

        /// <summary>
        /// Test the ParameterDataController.GetParameters() method, make sure that the parameter
        /// objects returned from the controller have all required properties populated.
        /// </summary>
        [TestMethod]
        public void tCheckRetrievedParameter() {
            var report = ReportDataController.Get(TestMetadata.ReportName);
            var test = ParameterDataController.GetParameters(report);
            Assert.IsNotNull(test);
            Assert.IsTrue(test.Count() > 0);

            foreach(var param in test) {
                Assert.IsTrue(!string.IsNullOrEmpty(param.DBType));
                Assert.IsTrue(!string.IsNullOrEmpty(param.ParameterName));
            }
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
