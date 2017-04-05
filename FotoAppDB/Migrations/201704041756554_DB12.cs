namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Papers", "Availability", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Papers", "Availability", c => c.Int(nullable: false));
        }
    }
}
