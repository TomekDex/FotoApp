namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB6 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Prices");
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Area = c.String(nullable: false, maxLength: 10),
                        Target = c.String(nullable: false, maxLength: 10),
                        Value = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => new { t.Area, t.Target });
            
            AddPrimaryKey("dbo.Prices", new[] { "SizeID", "TypeID", "Quantity" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Prices");
            DropTable("dbo.Settings");
            AddPrimaryKey("dbo.Prices", new[] { "Quantity", "SizeID", "TypeID" });
        }
    }
}
