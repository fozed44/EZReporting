using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EZDataFramework.Framework {
    public class ReportColumn {

        [Key]
        public int    pkID         { get; set; }
        public string ColumnName   { get; set; } 
        public int    Flags        { get; set; }
        public string DBType       { get; set; }
        public string Formatter    { get; set; }
        public string Converter    { get; set; }
        public int    FormatFlags  { get; set; }
        public int    ConvertFlags { get; set; }

        [ForeignKey("Report")]
        public int            fkReport { get; set; }
        public virtual Report Report   { get; set; }

        public virtual List<ReportColumnCustomization> Customizations { get; set; }
    }
}
