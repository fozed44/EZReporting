namespace EZDataFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Required_To_Name_Columns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Alignments", "DisplayName", c => c.String(nullable: false));
            AlterColumn("dbo.Reports", "ReportName", c => c.String(nullable: false));
            AlterColumn("dbo.ConnectionStrings", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ConnectionStrings", "Value", c => c.String(nullable: false));
            AlterColumn("dbo.TableStyles", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TableStyles", "Name", c => c.String());
            AlterColumn("dbo.ConnectionStrings", "Value", c => c.String());
            AlterColumn("dbo.ConnectionStrings", "Name", c => c.String());
            AlterColumn("dbo.Reports", "ReportName", c => c.String());
            AlterColumn("dbo.Alignments", "DisplayName", c => c.String());
        }
    }
}
