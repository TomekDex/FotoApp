namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Discounts", "PaperID", "dbo.Papers");
            DropIndex("dbo.Discounts", new[] { "PaperID" });
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PaperID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.PaperID, t.Quantity })
                .ForeignKey("dbo.Papers", t => t.PaperID, cascadeDelete: true)
                .Index(t => t.PaperID);
            
            DropColumn("dbo.Papers", "Cost");
            DropTable("dbo.Discounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        PaperID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.PaperID, t.Quantity });
            
            AddColumn("dbo.Papers", "Cost", c => c.Double(nullable: false));
            DropForeignKey("dbo.Prices", "PaperID", "dbo.Papers");
            DropIndex("dbo.Prices", new[] { "PaperID" });
            DropTable("dbo.Prices");
            CreateIndex("dbo.Discounts", "PaperID");
            AddForeignKey("dbo.Discounts", "PaperID", "dbo.Papers", "PaperID", cascadeDelete: true);
        }
    }
}
