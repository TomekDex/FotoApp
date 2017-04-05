namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Papers", "Availability", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Papers", "Availability");
        }
    }
}
