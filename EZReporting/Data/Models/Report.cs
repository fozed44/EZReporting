
namespace EZReporting.Data {

    /// <summary>
    //++ Report
    ///
    //+  Purpose:
    ///     EZReporting.Data.Report is a byte for byte equivalent to DataFramework.Framework.Report.
    ///     The type is needed so that consumers of the EZReporting assembly do not need a dependency
    ///     on the DataFramework assembly.
    /// </summary>
    public class Report {

        public Report() { }

        public Report(DataFramework.Framework.Report report) {
            pkID         = report.pkID;
            ReportName   = report.ReportName;
            ProcName     = report.ProcName;
            DatabaseName = report.DatabaseName;
            SchemaName   = report.SchemaName;
            Renderer     = report.Renderer;
        }

        public int    pkID         { get; set; }
        public string ReportName   { get; set; }
        public string ProcName     { get; set; }
        public string DatabaseName { get; set; }
        public string SchemaName   { get; set; }
        public string Renderer     { get; set; }

        public DataFramework.Framework.Report ToFramework() {
            return new DataFramework.Framework.Report {
                pkID         = this.pkID,
                ReportName   = this.ReportName,
                ProcName     = this.ProcName,
                DatabaseName = this.DatabaseName,
                SchemaName   = this.SchemaName,
                Renderer     = this.Renderer
            };
        }
    }
}
