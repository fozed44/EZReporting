namespace EZDataFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDBTypeToReportParameter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReportParameters", "DBType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReportParameters", "DBType");
        }
    }
}
