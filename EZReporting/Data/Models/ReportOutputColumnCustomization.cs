
namespace EZReporting.Data {

    /// <summary>
    //++ ReportOutputColumnCustomization
    ///
    //+  Purpose:
    ///     EZReporting.Data.ReportOutputColumnCustomization is a byte for byte equivalent to 
    ///     DataFramework.Framework.ReortOutputColumnCustomization.
    ///     The type is needed so that consumers of the EZReporting assembly do not need a dependency
    ///     on the DataFramework assembly.
    /// </summary>
    public class ReportOutputColumnCustomization {

        public ReportOutputColumnCustomization() { }

        public ReportOutputColumnCustomization(DataFramework.Framework.ReportOutputColumnCustomization c) {
            pkID        = c.pkID;
            fkUser      = c.fkUser;
            fkColumn    = c.fkColumn;
            Position    = c.Position;
            DisplayName = c.DisplayName;
            DisplayType = c.DisplayType;
        }

        public int    pkID        { get; set; }
        public int    fkUser      { get; set; }
        public int    Position    { get; set; }
        public int    Flags       { get; set; }
        public string DisplayName { get; set; }
        public int    fkColumn    { get; set; }
        public string DisplayType { get; set; }

        public DataFramework.Framework.ReportOutputColumnCustomization ToFramework() {
            return new DataFramework.Framework.ReportOutputColumnCustomization {
                pkID        = this.pkID,
                fkUser      = this.fkUser,
                fkColumn    = this.fkColumn,
                Position    = this.Position,
                DisplayName = this.DisplayName,
                DisplayType = this.DisplayType,
                Flags       = this.Flags
            };
        }
    }
}
