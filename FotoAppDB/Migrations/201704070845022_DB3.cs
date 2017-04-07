namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sizes", "height", c => c.Single(nullable: false));
            AddColumn("dbo.Sizes", "length", c => c.Single(nullable: false));
            DropColumn("dbo.Sizes", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sizes", "Size", c => c.String());
            DropColumn("dbo.Sizes", "length");
            DropColumn("dbo.Sizes", "height");
        }
    }
}
