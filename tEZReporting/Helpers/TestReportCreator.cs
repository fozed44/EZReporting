using System;
using EZDataFramework.Framework;
using EZReporting.Data;

namespace tEZReporting.Helpers {
    public static class TestReportCreator {

        #region Fields

        private static Report           _testReport;
        private static ConnectionString _connectionString;
        private static TableStyle       _tableStyle;
        #endregion

        #region Public

        public static void EnsureCreated() {
            if(!TestReportExists())
                CreateTestReport();
        }

        public static void EnsureRemoved() {
            while(TestReportExists()) {
                DeleteTestReport();
            }
        }

        #endregion

        #region Private

        private static Report CreateTestReport() {
            using(var disposerToken = new DataControllerBase.DisposerToken()) {
                _connectionString = new ConnectionString {
                    Name  = "TestConnectionStringName",
                    Value = "TestConnectionStringValue"
                };
                ConnectionStringDataController.AddConnectionString(_connectionString);
                _tableStyle = new TableStyle {
                    Name           = "TestTableStyle",
                    CellStyle      = "CellStyleCss",
                    EvenRowStyle   = "EvenRowStyleCss",
                    OddRowStyle    = "OddRowStyleCss",
                    HeaderRowStyle = "HeaderRowStyleCss",
                    HeaderStyle    = "HeaderStyleCss",
                    RowStyle       = "RowStyleCss",
                    Style          = "StyleCss"
                };
                TableStyleDataController.AddTableStyle(_tableStyle);
                _testReport = new Report {
                    fkTableStyle       = _tableStyle.pkID,
                    fkConnectionString = _connectionString.pkID,
                    DatabaseName       = TestMetadata.DatabaseName,
                    SchemaName         = TestMetadata.SchemaName,
                    ProcName           = TestMetadata.ProcName,
                    ReportName         = TestMetadata.ReportName
                };
                return ReportDataController.Create(_testReport);
            }
        }

        private static void ReloadTestReport() {
            using(var disposerToken = new DataControllerBase.DisposerToken()) {
                _testReport = ReportDataController.Get(TestMetadata.ReportName);
            }
        }

        private static bool TestReportExists() {
            using(var desposerToken = new DataControllerBase.DisposerToken()) {
                return ReportDataController.Exists(TestMetadata.ReportName);
            }
        }

        private static void DeleteTestReport() {
            ReloadTestReport();
            using(var disposerToken = new DataControllerBase.DisposerToken()) {
                ReportDataController.Delete(_testReport);
                ConnectionStringDataController.DeleteConnectionString(_connectionString);
                TableStyleDataController.DeleteTableStyle(_tableStyle);
            }
        }

        #endregion
    }
}
