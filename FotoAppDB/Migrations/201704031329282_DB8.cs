namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
        }
    }
}
