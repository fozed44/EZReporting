using System.ComponentModel.DataAnnotations;

namespace EZDataFramework.Framework {
    public class ConnectionString {
        [Key]
        public int    pkID  { get; set; }
        [Required]
        public string Name  { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
