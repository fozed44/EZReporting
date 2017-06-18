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

        [TestMethod]
        public void tGetDataProvider() {
            try {
                TestReportCreator.EnsureCreated();
                using(var disposerToken = new DataControllerBase.DisposerToken()) {
                    var report = ReportDataController.Get(TestMetadata.ReportName);
                    var result = ImplementationFactory.GetDataProvider(report);
                    Assert.AreEqual(typeof(DefaultDataProvider), result.GetType());
                }
            } finally {
                TestReportCreator.EnsureRemoved();
            }
        }

        [TestMethod]
        public void tGetRenderer() {
            try {
                TestReportCreator.EnsureCreated();
                using(var disposerToken = new ReportDataController.DisposerToken()) {
                    var report = ReportDataController.Get(TestMetadata.ReportName);
                    var result = ImplementationFactory.GetRenderer(report);
                    Assert.AreEqual(typeof(DefaultRenderer), result.GetType());
                }
            } finally {
                TestReportCreator.EnsureRemoved();
            }
        }

        [TestMethod]
        public void tGetFormatter() {
            try {
                TestReportCreator.EnsureCreated();
                using(var disposerToken = new ReportDataController.DisposerToken()) {
                    var report = ReportDataController.Get(TestMetadata.ReportName);
                    var result = ImplementationFactory.GetFormatter(report, 0);
                    Assert.AreEqual(typeof(DefaultFormatter), result.GetType()); 
                }
            } finally {
                TestReportCreator.EnsureRemoved();
            }
        }

        [TestMethod]
        public void tGetFormatters() {
            try {
                TestReportCreator.EnsureCreated();
                using(var disposerToken = new DataControllerBase.DisposerToken()) {
                    var report = ReportDataController.Get(TestMetadata.ReportName);
                    var reportOutputColumns = ColumnDataController.GetColumns(report);
                    var result = ImplementationFactory.GetFormatters(report);
                    Assert.IsTrue(result.Count() == reportOutputColumns.Count()); 
                }
            } finally {
                TestReportCreator.EnsureRemoved();
            }
        }

    }
}
