namespace EZDataFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReportColumnCustomizations",
                c => new
                    {
                        pkID = c.Int(nullable: false, identity: true),
                        User = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                        Flags = c.Int(nullable: false),
                        Hide = c.Boolean(nullable: false),
                        fkReportColumn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pkID)
                .ForeignKey("dbo.ReportColumns", t => t.fkReportColumn, cascadeDelete: true)
                .Index(t => t.fkReportColumn);
            
            CreateTable(
                "dbo.ReportColumns",
                c => new
                    {
                        pkID = c.Int(nullable: false, identity: true),
                        ColumnName = c.String(),
                        Flags = c.Int(nullable: false),
                        DBType = c.String(),
                        Formatter = c.String(),
                        Converter = c.String(),
                        FormatFlags = c.Int(nullable: false),
                        ConvertFlags = c.Int(nullable: false),
                        fkReport = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pkID)
                .ForeignKey("dbo.Reports", t => t.fkReport, cascadeDelete: true)
                .Index(t => t.fkReport);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        pkID = c.Int(nullable: false, identity: true),
                        ReportName = c.String(),
                        ProcName = c.String(),
                        SchemaName = c.String(),
                        DatabaseName = c.String(),
                        Renderer = c.String(),
                    })
                .PrimaryKey(t => t.pkID);
            
            CreateTable(
                "dbo.ReportParameters",
                c => new
                    {
                        pkID = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        Flags = c.Int(nullable: false),
                        ParameterName = c.String(),
                        fkReport = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pkID)
                .ForeignKey("dbo.Reports", t => t.fkReport, cascadeDelete: true)
                .Index(t => t.fkReport);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportColumnCustomizations", "fkReportColumn", "dbo.ReportColumns");
            DropForeignKey("dbo.ReportColumns", "fkReport", "dbo.Reports");
            DropForeignKey("dbo.ReportParameters", "fkReport", "dbo.Reports");
            DropIndex("dbo.ReportParameters", new[] { "fkReport" });
            DropIndex("dbo.ReportColumns", new[] { "fkReport" });
            DropIndex("dbo.ReportColumnCustomizations", new[] { "fkReportColumn" });
            DropTable("dbo.ReportParameters");
            DropTable("dbo.Reports");
            DropTable("dbo.ReportColumns");
            DropTable("dbo.ReportColumnCustomizations");
        }
    }
}
