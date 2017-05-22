using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EZDataFramework.Framework {
    public class Report {
        [Key]
        public int    pkID         { get; set; }
        public string ReportName   { get; set; }
        public string ProcName     { get; set; }
        public string SchemaName   { get; set; }
        public string DatabaseName { get; set; }
        public string Renderer     { get; set; }        

        [ForeignKey("ConnectionString")]
        public int fkConnectionString { get; set; }       
        
        [ForeignKey("TableStyle")]
        public int fkTableStyle       { get; set; }

        public virtual List<ReportColumn>    Columns          { get; set; }
        public virtual List<ReportParameter> Parameters       { get; set; }
        public virtual ConnectionString      ConnectionString { get; set; }
        public virtual Alignment             Alignment        { get; set; }
        public virtual TableStyle            TableStyle       { get; set; }
    }
}
