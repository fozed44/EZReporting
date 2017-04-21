

using System;

namespace EZReporting.Enumeration {
    public class EnumeratedInput {
        public string Name              { get; set; }
        public string DataType          { get; set; }
        public Int16  MaxBytes          { get; set; }
        public Int32  ID                { get; set; }
        public bool   IsOutputParameter { get; set; }
    }
}
