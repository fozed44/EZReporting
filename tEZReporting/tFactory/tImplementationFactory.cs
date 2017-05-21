using System.Linq;
using EZDataFramework.Framework;
using EZReporting.Data;
using EZReporting.Factory;
using EZReporting.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tEZReporting.Helpers;

namespace tEZReporting.tFactory {

    [TestClass]
    public class tImplementationFactory {
        
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
        public void tGetDataProvider() {
            var report = ReportDataController.Get(TestMetadata.ReportName);
            var result = ImplementationFactory.GetDataProvider(report);
            Assert.AreEqual(typeof(DefaultDataProvider), result.GetType());
        }

        [TestMethod]
        public void tGetRenderer() {
            var report = ReportDataController.Get(TestMetadata.ReportName);
            var result = ImplementationFactory.GetRenderer(report);
            Assert.AreEqual(typeof(DefaultRenderer), result.GetType());
        }

        [TestMethod]
        public void tGetFormatter() {
            var report = ReportDataController.Get(TestMetadata.ReportName);
            var result = ImplementationFactory.GetFormatter(report, 0);
            Assert.AreEqual(typeof(DefaultFormatter), result.GetType());
        }

        [TestMethod]
        public void tGetFormatters() {
            var report = ReportDataController.Get(TestMetadata.ReportName);
            var reportOutputColumns = ColumnDataController.GetColumns(report);
            var result = ImplementationFactory.GetFormatters(report);
            Assert.IsTrue(result.Count() == reportOutputColumns.Count());
        }

        #region Private

        private static void CreateTestReport() {
            ReportDataController.Create(new Report {
                ReportName   = TestMetadata.ReportName,
                DatabaseName = TestMetadata.DatabaseName,
                SchemaName   = TestMetadata.SchemaName,
                ProcName     = TestMetadata.ProcName
            });
        }

        private static void DeleteTestReport() {
            ReportDataController.Delete(TestMetadata.ReportName);
        }

        #endregion

    }
}
