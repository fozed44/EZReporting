namespace EZDataFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Alignment_Property_From_Report : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reports", "Alignment_pkID", "dbo.Alignments");
            DropIndex("dbo.Reports", new[] { "Alignment_pkID" });
            DropColumn("dbo.Reports", "Alignment_pkID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "Alignment_pkID", c => c.Int());
            CreateIndex("dbo.Reports", "Alignment_pkID");
            AddForeignKey("dbo.Reports", "Alignment_pkID", "dbo.Alignments", "pkID");
        }
    }
}
