using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EZDataFramework.Framework {
    public class Report {
        [Key]
        public int    pkID         { get; set; }
        public string ReportName   { get; set; }
        public string ProcName     { get; set; }
        public string SchemaName   { get; set; }
        public string DatabaseName { get; set; }
        public string Renderer     { get; set; }
        
        public List<ReportColumn>    Columns    { get; set; }
        public List<ReportParameter> Parameters { get; set; }
    }
}
