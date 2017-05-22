namespace EZDataFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableStyle_TableAlignment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alignments",
                c => new
                    {
                        pkID = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        Css = c.String(),
                    })
                .PrimaryKey(t => t.pkID);
            
            CreateTable(
                "dbo.ConnectionStrings",
                c => new
                    {
                        pkID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.pkID);
            
            CreateTable(
                "dbo.TableStyles",
                c => new
                    {
                        pkID = c.Int(nullable: false, identity: true),
                        Style = c.String(),
                        HeaderRowStyle = c.String(),
                        HeaderStyle = c.String(),
                        RowStyle = c.String(),
                        EvenRowStyle = c.String(),
                        OddRowStyle = c.String(),
                        CellStyle = c.String(),
                    })
                .PrimaryKey(t => t.pkID);
            
            AddColumn("dbo.ReportColumns", "Css", c => c.String());
            AddColumn("dbo.ReportColumns", "fkAlignment", c => c.Int(nullable: false));
            AddColumn("dbo.Reports", "fkConnectionString", c => c.Int(nullable: false));
            AddColumn("dbo.Reports", "fkTableStyle", c => c.Int(nullable: false));
            AddColumn("dbo.Reports", "Alignment_pkID", c => c.Int());
            CreateIndex("dbo.ReportColumns", "fkAlignment");
            CreateIndex("dbo.Reports", "fkConnectionString");
            CreateIndex("dbo.Reports", "fkTableStyle");
            CreateIndex("dbo.Reports", "Alignment_pkID");
            AddForeignKey("dbo.ReportColumns", "fkAlignment", "dbo.Alignments", "pkID", cascadeDelete: true);
            AddForeignKey("dbo.Reports", "Alignment_pkID", "dbo.Alignments", "pkID");
            AddForeignKey("dbo.Reports", "fkConnectionString", "dbo.ConnectionStrings", "pkID", cascadeDelete: true);
            AddForeignKey("dbo.Reports", "fkTableStyle", "dbo.TableStyles", "pkID", cascadeDelete: true);
            DropColumn("dbo.ReportColumns", "Flags");
            DropColumn("dbo.ReportColumns", "FormatFlags");
            DropColumn("dbo.ReportColumns", "ConvertFlags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReportColumns", "ConvertFlags", c => c.Int(nullable: false));
            AddColumn("dbo.ReportColumns", "FormatFlags", c => c.Int(nullable: false));
            AddColumn("dbo.ReportColumns", "Flags", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reports", "fkTableStyle", "dbo.TableStyles");
            DropForeignKey("dbo.Reports", "fkConnectionString", "dbo.ConnectionStrings");
            DropForeignKey("dbo.Reports", "Alignment_pkID", "dbo.Alignments");
            DropForeignKey("dbo.ReportColumns", "fkAlignment", "dbo.Alignments");
            DropIndex("dbo.Reports", new[] { "Alignment_pkID" });
            DropIndex("dbo.Reports", new[] { "fkTableStyle" });
            DropIndex("dbo.Reports", new[] { "fkConnectionString" });
            DropIndex("dbo.ReportColumns", new[] { "fkAlignment" });
            DropColumn("dbo.Reports", "Alignment_pkID");
            DropColumn("dbo.Reports", "fkTableStyle");
            DropColumn("dbo.Reports", "fkConnectionString");
            DropColumn("dbo.ReportColumns", "fkAlignment");
            DropColumn("dbo.ReportColumns", "Css");
            DropTable("dbo.TableStyles");
            DropTable("dbo.ConnectionStrings");
            DropTable("dbo.Alignments");
        }
    }
}
