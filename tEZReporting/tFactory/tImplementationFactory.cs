using System.Linq;
using EZReporting.Data;
using EZReporting.Factory;
using EZReporting.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tEZReporting.tFactory {

    [TestClass]
    public class tImplementationFactory {

        private static string _tReport   = "__ImplementationFactoryTest";
        private static string _tDatabase = "OnlineRisk";
        private static string _tSchema   = "dbo";
        private static string _tProc     = "RiskReport";

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
            var report = ReportDataController.Get(_tReport);
            var result = ImplementationFactory.GetDataProvider(report);
            Assert.AreEqual(typeof(DefaultDataProvider), result.GetType());
        }

        [TestMethod]
        public void tGetRenderer() {
            var report = ReportDataController.Get(_tReport);
            var result = ImplementationFactory.GetRenderer(report);
            Assert.AreEqual(typeof(DefaultRenderer), result.GetType());
        }

        [TestMethod]
        public void tGetFormatter() {
            var report = ReportDataController.Get(_tReport);
            var result = ImplementationFactory.GetFormatter(report, 0);
            Assert.AreEqual(typeof(DefaultFormatter), result.GetType());
        }

        [TestMethod]
        public void tGetFormatters() {
            var report = ReportDataController.Get(_tReport);
            var reportOutputColumns = ColumnDataController.GetColumns(report);
            var result = ImplementationFactory.GetFormatters(report);
            Assert.IsTrue(result.Count() == reportOutputColumns.Count());
        }

        private static void CreateTestReport() {
            ReportDataController.Create(new Report {
                ReportName   = _tReport,
                DatabaseName = _tDatabase,
                SchemaName   = _tSchema,
                ProcName     = _tProc
            });
        }

        private static void DeleteTestReport() {
            ReportDataController.Delete(_tReport);
        }

    }
}
