namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Prices", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prices", "Price", c => c.Double(nullable: false));
        }
    }
}
