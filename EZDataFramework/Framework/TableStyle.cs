using System.ComponentModel.DataAnnotations;

namespace EZDataFramework.Framework {
    public class TableStyle {
        [Key]
        public int    pkID           { get; set; }
        public string Name           { get; set; }
        public string Style          { get; set; }
        public string HeaderRowStyle { get; set; }
        public string HeaderStyle    { get; set; }
        public string RowStyle       { get; set; }
        public string EvenRowStyle   { get; set; }
        public string OddRowStyle    { get; set; }
        public string CellStyle      { get; set; }
    }
}
