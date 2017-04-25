﻿
namespace EZReporting.Data {

    /// <summary>
    //++ ReportOutputColumn
    ///
    //+  Purpose:
    ///     EZReporting.Data.ReportOuputColumn is a byte for byte equivalent to DataFramework.Framework.ReportOutputColum.
    ///     The type is needed so that consumers of the EZReporting assembly do not need a dependency
    ///     on the DataFramework assembly.
    /// </summary>
    public class ReportOutputColumn {

        public ReportOutputColumn() { }
        
        public ReportOutputColumn(DataFramework.Framework.ReportOutputColumn c) {
            pkID         = c.pkID;
            fkReport     = c.fkReport;
            ColumnName   = c.ColumnName;
            Formatter    = c.Formatter;
            Converter    = c.Converter;
            Flags        = c.Flags;
            DBType       = c.DBType;
            FormatFlags  = c.FormatFlags;
            ConvertFlags = c.ConvertFlags;
        }

        public int    pkID         { get; set; }
        public int    fkReport     { get; set; }
        public string ColumnName   { get; set; }
        public string Formatter    { get; set; }
        public string Converter    { get; set; }
        public int    Flags        { get; set; }
        public string DBType       { get; set; }
        public int?   FormatFlags  { get; set; }
        public int?   ConvertFlags { get; set; }

        public DataFramework.Framework.ReportOutputColumn ToFramework() {
            return new DataFramework.Framework.ReportOutputColumn {
                pkID         = this.pkID,
                fkReport     = this.fkReport,
                ColumnName   = this.ColumnName,
                Formatter    = this.Formatter,
                Converter    = this.Converter,
                Flags        = this.Flags,
                DBType       = this.DBType,
                FormatFlags  = this.FormatFlags,
                ConvertFlags = this.ConvertFlags
            };
        }
    }
}
