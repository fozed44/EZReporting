using System.ComponentModel.DataAnnotations;

namespace EZDataFramework.Framework {
    public class ConnectionString {
        [Key]
        public int    pkID  { get; set; }
        public string Name  { get; set; }
        public string Value { get; set; }
    }
}
