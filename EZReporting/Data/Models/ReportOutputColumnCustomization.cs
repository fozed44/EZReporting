
namespace EZReporting.Data {

    /// <summary>
    //++ ReportColumnCustomization
    ///
    //+  Purpose:
    ///     EZReporting.Data.ReportColumnCustomization is a byte for byte equivalent to 
    ///     EZDataFramework.Framework.ReortOutputColumnCustomization.
    ///     The type is needed so that consumers of the EZReporting assembly do not need a dependency
    ///     on the EZDataFramework assembly.
    /// </summary>
    public class ReportColumnCustomization {

        public ReportColumnCustomization() { }

        public ReportColumnCustomization(EZDataFramework.Framework.ReportColumnCustomization c) {
            pkID        = c.pkID;
            fkUser      = c.User;
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

        public EZDataFramework.Framework.ReportColumnCustomization ToFramework() {
            return new EZDataFramework.Framework.ReportColumnCustomization {
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
