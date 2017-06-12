using System;
using EZDataFramework.Framework;
using EZReporting.Data;

namespace tEZReporting.Helpers {
    public static class TestReportCreator {

        #region Fields

        private static Report _testReport;

        #endregion

        #region Public

        public static Report CreateTestReport() {
            using(var disposerToken = new DataControllerBase.DisposerToken()) {
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
                return ReportDataController.Create(_testReport);
            }
        }

        public static void DeleteTestReport() {
            using(var disposerToken = new DataControllerBase.DisposerToken()) {
                try {
                    ReportDataController.Delete(_testReport);
                    ConnectionStringDataController.DeleteConnectionString(_testReport.ConnectionString);
                    TableStyleDataController.DeleteTableStyle(_testReport.TableStyle);
                    DataControllerBase.SaveChanges();
                } catch(Exception e) {
                    var x = 1;
                    x++;
                }
            }
        }

        #endregion
    }
}
