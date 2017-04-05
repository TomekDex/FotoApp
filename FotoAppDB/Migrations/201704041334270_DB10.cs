namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fotos", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fotos", "Name");
        }
    }
}
