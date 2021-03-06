﻿
namespace EZReporting.Data {

    /// <summary>
    //++ ReportParameter
    ///
    //+  Purpose:
    ///     EZReporting.Data.ReportParameter is a byte for byte equivalent to EZDataFramework.Framework.ReportParameter.
    ///     The type is needed so that consumers of the EZReporting assembly do not need a dependency
    ///     on the EZDataFramework assembly.
    /// </summary>
    public class ReportParameter {

        public ReportParameter() { }

        public ReportParameter(EZDataFramework.Framework.ReportParameter p) {
            pkID          = p.pkID;
            fkReport      = p.fkReport;
            DisplayName   = p.DisplayName;
            Flags         = p.Flags;
            DBType        = p.DBType;
            ParameterName = p.ParameterName;
        }

        public int    pkID          { get; set; }
        public int    fkReport      { get; set; }
        public string DisplayName   { get; set; }
        public int    Flags         { get; set; }
        public string DBType        { get; set; }
        public string ParameterName { get; set; }

        public EZDataFramework.Framework.ReportParameter ToFramework() {
            return new EZDataFramework.Framework.ReportParameter {
                pkID          = this.pkID,
                fkReport      = this.fkReport,
                DisplayName   = this.DisplayName,
                Flags         = this.Flags,
                DBType        = this.DBType,
                ParameterName = this.ParameterName
            };
        }
    }
}
