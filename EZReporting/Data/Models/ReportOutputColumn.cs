
namespace EZReporting.Data {

    /// <summary>
    //++ ReportColumn
    ///
    //+  Purpose:
    ///     EZReporting.Data.ReportOuputColumn is a byte for byte equivalent to EZDataFramework.Framework.ReportOutputColum.
    ///     The type is needed so that consumers of the EZReporting assembly do not need a dependency
    ///     on the EZDataFramework assembly.
    /// </summary>
    public class ReportColumn {

        public ReportColumn() { }
        
        public ReportColumn(EZDataFramework.Framework.ReportColumn c) {
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

        public EZDataFramework.Framework.ReportColumn ToFramework() {
            return new EZDataFramework.Framework.ReportColumn {
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
