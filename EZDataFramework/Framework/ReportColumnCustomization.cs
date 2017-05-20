using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EZDataFramework.Framework {
    public class ReportColumnCustomization {
        [Key]
        public int pkID { get; set; }
        public int User { get; set; }
        public int Position { get; set; }
        public int Flags { get; set; }
        public bool Hide { get; set; }

        [ForeignKey("ReportColumn")]
        public int fkReportColumn { get; set; }
        public virtual ReportColumn ReportColumn { get; set; }
    }
}