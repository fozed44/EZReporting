namespace EZDataFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Table_Style_Name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TableStyles", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TableStyles", "Name");
        }
    }
}
