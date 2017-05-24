using System;
using EZDataFramework.Framework;
using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tEZReporting.Helpers;

namespace tEZReporting.tControllers {
    [TestClass]
    public class tReportDataController {

        #region Fields

        Report _testReport;

        #endregion

        [ClassInitialize]
        public static void tInitialize(TestContext c) {
            ReportDataController.Delete(TestMetadata.ReportName);
        }

        [TestMethod]
        public void tExits_FailA() {
            var result = ReportDataController.Exists(TestMetadata.ReportName);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void tCreate() {
            bool result = false;
            CreateTestReport();
            try {
                result = ReportDataController.Exists(TestMetadata.ReportName);
            } finally {
                DeleteTestReport(_testReport);
            }
            Assert.IsTrue(result);
        }

        #region Private

        private void CreateTestReport() {
            var connectionString = new ConnectionString {
                Name  = "TestConnectionStringName",
                Value = "TestConnectionStringValue"
            };
            ConnectionStringDataController.AddConnectionString(connectionString);
            var tableStyle = new TableStyle {
                CellStyle      = "CellStyleCss",
                EvenRowStyle   = "EvenRowStyleCss",
                OddRowStyle    = "OddRowStyleCss",
                HeaderRowStyle = "HeaderRowStyleCss",
                HeaderStyle    = "HeaderStyleCss",
                RowStyle       = "RowStyleCss",
                Style          = "StyleCss"
            };
            TableStyleDataController.AddTableStyle(tableStyle);
            _testReport = new Report {
                fkTableStyle       = tableStyle.pkID,
                fkConnectionString = connectionString.pkID,
                DatabaseName       = TestMetadata.DatabaseName,
                SchemaName         = TestMetadata.SchemaName,
                ProcName           = TestMetadata.ProcName,
                ReportName         = TestMetadata.ReportName
            };
            ReportDataController.Create(_testReport);
        }

        private void DeleteTestReport(Report report) {
            ConnectionStringDataController.DeleteConnectionString(report.ConnectionString);
            TableStyleDataController.DeleteTableStyle(report.TableStyle);
            ReportDataController.Delete(report);
        }

        #endregion

    }
}
