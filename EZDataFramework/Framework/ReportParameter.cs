using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EZDataFramework.Framework {
    public class ReportParameter {
        [Key]
        public int    pkID          { get; set; }
        public string DisplayName   { get; set; }
        public int    Flags         { get; set; }
        public string ParameterName { get; set; }
        public string DBType        { get; set; }

        [ForeignKey("Report")]
        public int fkReport { get; set; }
        public virtual Report Report { get; set; }
    }

}
