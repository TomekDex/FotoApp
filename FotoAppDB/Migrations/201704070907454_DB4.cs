namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fotos", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Fotos", new[] { "SizeID", "TypeID" }, "dbo.Papers");
            DropIndex("dbo.Fotos", new[] { "OrderID" });
            DropIndex("dbo.Fotos", new[] { "SizeID", "TypeID" });
            DropPrimaryKey("dbo.Fotos");
            CreateTable(
                "dbo.OrderFotos",
                c => new
                    {
                        FotoID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        SizeID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FotoID, t.OrderID, t.SizeID, t.TypeID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Papers", t => new { t.SizeID, t.TypeID })
                .ForeignKey("dbo.Fotos", t => t.FotoID)
                .Index(t => t.FotoID)
                .Index(t => t.OrderID)
                .Index(t => new { t.SizeID, t.TypeID });
            
            AddPrimaryKey("dbo.Fotos", "FotoID");
            DropColumn("dbo.Fotos", "OrderID");
            DropColumn("dbo.Fotos", "SizeID");
            DropColumn("dbo.Fotos", "TypeID");
            DropColumn("dbo.Fotos", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fotos", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Fotos", "TypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Fotos", "SizeID", c => c.Int(nullable: false));
            AddColumn("dbo.Fotos", "OrderID", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderFotos", "FotoID", "dbo.Fotos");
            DropForeignKey("dbo.OrderFotos", new[] { "SizeID", "TypeID" }, "dbo.Papers");
            DropForeignKey("dbo.OrderFotos", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderFotos", new[] { "SizeID", "TypeID" });
            DropIndex("dbo.OrderFotos", new[] { "OrderID" });
            DropIndex("dbo.OrderFotos", new[] { "FotoID" });
            DropPrimaryKey("dbo.Fotos");
            DropTable("dbo.OrderFotos");
            AddPrimaryKey("dbo.Fotos", new[] { "FotoID", "OrderID", "SizeID", "TypeID" });
            CreateIndex("dbo.Fotos", new[] { "SizeID", "TypeID" });
            CreateIndex("dbo.Fotos", "OrderID");
            AddForeignKey("dbo.Fotos", new[] { "SizeID", "TypeID" }, "dbo.Papers", new[] { "SizeID", "TypeID" });
            AddForeignKey("dbo.Fotos", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
    }
}
