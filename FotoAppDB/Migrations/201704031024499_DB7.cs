namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "Data");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Data", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "Date");
        }
    }
}
