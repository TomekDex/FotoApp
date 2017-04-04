namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB1 : DbMigration
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
                "dbo.Texts",
                c => new
                    {
                        TextID = c.Int(nullable: false),
                        Language = c.String(nullable: false, maxLength: 5),
                        Text = c.String(nullable: false, maxLength: 20),
                        Papers_PaperID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TextID, t.Language })
                .ForeignKey("dbo.Languages", t => t.Language)
                .ForeignKey("dbo.Papers", t => t.Papers_PaperID)
                .Index(t => t.Language)
                .Index(t => t.Papers_PaperID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Language = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.Language);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fotos", "PaperID", "dbo.Papers");
            DropForeignKey("dbo.Fotos", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Discounts", "PaperID", "dbo.Papers");
            DropForeignKey("dbo.Texts", "Papers_PaperID", "dbo.Papers");
            DropForeignKey("dbo.Texts", "Language", "dbo.Languages");
            DropForeignKey("dbo.Contacts", "OrderID", "dbo.Orders");
            DropIndex("dbo.Fotos", new[] { "PaperID" });
            DropIndex("dbo.Fotos", new[] { "OrderID" });
            DropIndex("dbo.Texts", new[] { "Papers_PaperID" });
            DropIndex("dbo.Texts", new[] { "Language" });
            DropIndex("dbo.Discounts", new[] { "PaperID" });
            DropIndex("dbo.Contacts", new[] { "OrderID" });
            DropTable("dbo.Fotos");
            DropTable("dbo.Languages");
            DropTable("dbo.Texts");
            DropTable("dbo.Papers");
            DropTable("dbo.Discounts");
            DropTable("dbo.Orders");
            DropTable("dbo.Contacts");
        }
    }
}
