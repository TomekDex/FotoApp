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
                        Mail = c.String(maxLength: 255),
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
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Fotos",
                c => new
                    {
                        FotoID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        SizeID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.FotoID, t.OrderID, t.SizeID, t.TypeID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Papers", t => new { t.SizeID, t.TypeID })
                .Index(t => t.OrderID)
                .Index(t => new { t.SizeID, t.TypeID });
            
            CreateTable(
                "dbo.Papers",
                c => new
                    {
                        SizeID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        Availability = c.Int(),
                    })
                .PrimaryKey(t => new { t.SizeID, t.TypeID })
                .ForeignKey("dbo.Sizes", t => t.SizeID)
                .ForeignKey("dbo.Types", t => t.TypeID)
                .Index(t => t.SizeID)
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Quantity = c.Int(nullable: false),
                        SizeID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Quantity, t.SizeID, t.TypeID })
                .ForeignKey("dbo.Papers", t => new { t.SizeID, t.TypeID })
                .Index(t => new { t.SizeID, t.TypeID });
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        SizeID = c.Int(nullable: false, identity: true),
                        TextID = c.Int(nullable: false),
                        Size = c.String(),
                    })
                .PrimaryKey(t => t.SizeID);
            
            CreateTable(
                "dbo.SizeTexts",
                c => new
                    {
                        TextID = c.Int(nullable: false),
                        Language = c.String(nullable: false, maxLength: 50),
                        Text = c.String(),
                    })
                .PrimaryKey(t => new { t.TextID, t.Language })
                .ForeignKey("dbo.Languages", t => t.Language)
                .ForeignKey("dbo.Sizes", t => t.TextID)
                .Index(t => t.TextID)
                .Index(t => t.Language);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Language = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Language);
            
            CreateTable(
                "dbo.TypeTexts",
                c => new
                    {
                        TextID = c.Int(nullable: false),
                        Language = c.String(nullable: false, maxLength: 50),
                        Text = c.String(),
                    })
                .PrimaryKey(t => new { t.TextID, t.Language })
                .ForeignKey("dbo.Types", t => t.TextID)
                .ForeignKey("dbo.Languages", t => t.Language)
                .Index(t => t.TextID)
                .Index(t => t.Language);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        TextID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SizeTexts", "TextID", "dbo.Sizes");
            DropForeignKey("dbo.TypeTexts", "Language", "dbo.Languages");
            DropForeignKey("dbo.TypeTexts", "TextID", "dbo.Types");
            DropForeignKey("dbo.Papers", "TypeID", "dbo.Types");
            DropForeignKey("dbo.SizeTexts", "Language", "dbo.Languages");
            DropForeignKey("dbo.Papers", "SizeID", "dbo.Sizes");
            DropForeignKey("dbo.Prices", new[] { "SizeID", "TypeID" }, "dbo.Papers");
            DropForeignKey("dbo.Fotos", new[] { "SizeID", "TypeID" }, "dbo.Papers");
            DropForeignKey("dbo.Fotos", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Contacts", "OrderID", "dbo.Orders");
            DropIndex("dbo.TypeTexts", new[] { "Language" });
            DropIndex("dbo.TypeTexts", new[] { "TextID" });
            DropIndex("dbo.SizeTexts", new[] { "Language" });
            DropIndex("dbo.SizeTexts", new[] { "TextID" });
            DropIndex("dbo.Prices", new[] { "SizeID", "TypeID" });
            DropIndex("dbo.Papers", new[] { "TypeID" });
            DropIndex("dbo.Papers", new[] { "SizeID" });
            DropIndex("dbo.Fotos", new[] { "SizeID", "TypeID" });
            DropIndex("dbo.Fotos", new[] { "OrderID" });
            DropIndex("dbo.Contacts", new[] { "OrderID" });
            DropTable("dbo.Types");
            DropTable("dbo.TypeTexts");
            DropTable("dbo.Languages");
            DropTable("dbo.SizeTexts");
            DropTable("dbo.Sizes");
            DropTable("dbo.Prices");
            DropTable("dbo.Papers");
            DropTable("dbo.Fotos");
            DropTable("dbo.Orders");
            DropTable("dbo.Contacts");
        }
    }
}
