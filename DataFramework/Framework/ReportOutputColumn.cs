//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataFramework.Framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReportOutputColumn
    {
        public int pkID { get; set; }
        public int fkReport { get; set; }
        public string ColumnName { get; set; }
        public string DisplayName { get; set; }
        public int Flags { get; set; }
    
        public virtual Report Report { get; set; }
    }
}
