namespace EZDataFramework.Framework {
    using System.Data.Entity;

    public class EZReportingEntities : DbContext {
        public EZReportingEntities()
            : base("name=EZReportingEntities") {
        }

        public virtual DbSet<Report>                    Reports              { get; set; }
        public virtual DbSet<ReportColumn>              Columns              { get; set; }
        public virtual DbSet<ReportColumnCustomization> ColumnCustomizations { get; set; }
        public virtual DbSet<ReportParameter>           Parameters           { get; set; }
    }
}