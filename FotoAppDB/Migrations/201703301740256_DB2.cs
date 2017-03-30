namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        Mail = c.String(),
                        TelephoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 200),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        PaperID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.PaperID, t.Quantity })
                .ForeignKey("dbo.Papers", t => t.PaperID, cascadeDelete: true)
                .Index(t => t.PaperID);
            
            CreateTable(
                "dbo.Papers",
                c => new
                    {
                        PaperID = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                        Paper = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PaperID);
            
            CreateTable(
                "dbo.Fotos",
                c => new
                    {
                        FotoID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        PaperID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Path = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.FotoID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Papers", t => t.PaperID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.PaperID);
            
            CreateTable(
                "dbo.OrdersFotos",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        FotoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Texts",
                c => new
                    {
                        TextID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.TextID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdersFotos", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Fotos", "PaperID", "dbo.Papers");
            DropForeignKey("dbo.Fotos", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Discounts", "PaperID", "dbo.Papers");
            DropForeignKey("dbo.Contacts", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrdersFotos", new[] { "OrderID" });
            DropIndex("dbo.Fotos", new[] { "PaperID" });
            DropIndex("dbo.Fotos", new[] { "OrderID" });
            DropIndex("dbo.Discounts", new[] { "PaperID" });
            DropIndex("dbo.Contacts", new[] { "OrderID" });
            DropTable("dbo.Texts");
            DropTable("dbo.OrdersFotos");
            DropTable("dbo.Fotos");
            DropTable("dbo.Papers");
            DropTable("dbo.Discounts");
            DropTable("dbo.Orders");
            DropTable("dbo.Contacts");
        }
    }
}
