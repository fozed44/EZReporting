
using System.ComponentModel.DataAnnotations;

namespace EZDataFramework.Framework {
    public class Alignment {
        [Key]
        public int    pkID        { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public string Css         { get; set; }
    }
}
