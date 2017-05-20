
namespace EZReporting.Data {

    /// <summary>
    //++ Report
    ///
    //+  Purpose:
    ///     EZReporting.Data.Report is a byte for byte equivalent to EZDataFramework.Framework.Report.
    ///     The type is needed so that consumers of the EZReporting assembly do not need a dependency
    ///     on the EZDataFramework assembly.
    /// </summary>
    public class Report {

        public Report() { }

        public Report(EZDataFramework.Framework.Report report) {
            pkID         = report.pkID;
            ReportName   = report.ReportName;
            ProcName     = report.ProcName;
            SchemaName   = report.SchemaName;
            DatabaseName = report.DatabaseName;
            Renderer     = report.Renderer;
        }

        public int    pkID         { get; set; }
        public string ReportName   { get; set; }
        public string ProcName     { get; set; }
        public string SchemaName   { get; set; }
        public string DatabaseName { get; set; }
        public string Renderer     { get; set; }

        public EZDataFramework.Framework.Report ToFramework() {
            return new EZDataFramework.Framework.Report {
                pkID         = this.pkID,
                ReportName   = this.ReportName,
                ProcName     = this.ProcName,
                SchemaName   = this.SchemaName,
                DatabaseName = this.DatabaseName,
                Renderer     = this.Renderer
            };
        }
    }
}
