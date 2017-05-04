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
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.FotoID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.OrderFotos",
                c => new
                    {
                        FotoID = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FotoID, t.Height, t.Width, t.TypeID })
                .ForeignKey("dbo.Papers", t => new { t.Height, t.Width, t.TypeID })
                .ForeignKey("dbo.Fotos", t => t.FotoID, cascadeDelete: true)
                .Index(t => t.FotoID)
                .Index(t => new { t.Height, t.Width, t.TypeID });
            
            CreateTable(
                "dbo.Papers",
                c => new
                    {
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        Availability = c.Int(),
                    })
                .PrimaryKey(t => new { t.Height, t.Width, t.TypeID })
                .ForeignKey("dbo.Sizes", t => new { t.Height, t.Width }, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeID, cascadeDelete: true)
                .Index(t => new { t.Height, t.Width })
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Height, t.Width, t.TypeID, t.Quantity })
                .ForeignKey("dbo.Papers", t => new { t.Height, t.Width, t.TypeID })
                .Index(t => new { t.Height, t.Width, t.TypeID });
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Height, t.Width });
            
            CreateTable(
                "dbo.SizeTexts",
                c => new
                    {
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Language = c.String(nullable: false, maxLength: 5),
                        Text = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => new { t.Height, t.Width, t.Language })
                .ForeignKey("dbo.Languages", t => t.Language)
                .ForeignKey("dbo.Sizes", t => new { t.Height, t.Width }, cascadeDelete: true)
                .Index(t => new { t.Height, t.Width })
                .Index(t => t.Language);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Language = c.String(nullable: false, maxLength: 5),
                        Base = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Language)
                .ForeignKey("dbo.Languages", t => t.Base)
                .Index(t => t.Base);
            
            CreateTable(
                "dbo.TypeTexts",
                c => new
                    {
                        TypeID = c.Int(nullable: false),
                        Language = c.String(nullable: false, maxLength: 5),
                        Text = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => new { t.TypeID, t.Language })
                .ForeignKey("dbo.Types", t => t.TypeID, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.Language)
                .Index(t => t.TypeID)
                .Index(t => t.Language);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        Connect = c.Int(),
                    })
                .PrimaryKey(t => t.TypeID)
                .ForeignKey("dbo.Types", t => t.Connect)
                .Index(t => t.Connect);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Area = c.String(nullable: false, maxLength: 10),
                        Type = c.String(nullable: false, maxLength: 10),
                        LogID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Message = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => new { t.Area, t.Type, t.LogID });
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Area = c.String(nullable: false, maxLength: 10),
                        Target = c.String(nullable: false, maxLength: 10),
                        Value = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => new { t.Area, t.Target });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fotos", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderFotos", "FotoID", "dbo.Fotos");
            DropForeignKey("dbo.SizeTexts", new[] { "Height", "Width" }, "dbo.Sizes");
            DropForeignKey("dbo.TypeTexts", "Language", "dbo.Languages");
            DropForeignKey("dbo.TypeTexts", "TypeID", "dbo.Types");
            DropForeignKey("dbo.Types", "Connect", "dbo.Types");
            DropForeignKey("dbo.Papers", "TypeID", "dbo.Types");
            DropForeignKey("dbo.SizeTexts", "Language", "dbo.Languages");
            DropForeignKey("dbo.Languages", "Base", "dbo.Languages");
            DropForeignKey("dbo.Papers", new[] { "Height", "Width" }, "dbo.Sizes");
            DropForeignKey("dbo.Prices", new[] { "Height", "Width", "TypeID" }, "dbo.Papers");
            DropForeignKey("dbo.OrderFotos", new[] { "Height", "Width", "TypeID" }, "dbo.Papers");
            DropForeignKey("dbo.Contacts", "OrderID", "dbo.Orders");
            DropIndex("dbo.Types", new[] { "Connect" });
            DropIndex("dbo.TypeTexts", new[] { "Language" });
            DropIndex("dbo.TypeTexts", new[] { "TypeID" });
            DropIndex("dbo.Languages", new[] { "Base" });
            DropIndex("dbo.SizeTexts", new[] { "Language" });
            DropIndex("dbo.SizeTexts", new[] { "Height", "Width" });
            DropIndex("dbo.Prices", new[] { "Height", "Width", "TypeID" });
            DropIndex("dbo.Papers", new[] { "TypeID" });
            DropIndex("dbo.Papers", new[] { "Height", "Width" });
            DropIndex("dbo.OrderFotos", new[] { "Height", "Width", "TypeID" });
            DropIndex("dbo.OrderFotos", new[] { "FotoID" });
            DropIndex("dbo.Fotos", new[] { "OrderID" });
            DropIndex("dbo.Contacts", new[] { "OrderID" });
            DropTable("dbo.Settings");
            DropTable("dbo.Logs");
            DropTable("dbo.Types");
            DropTable("dbo.TypeTexts");
            DropTable("dbo.Languages");
            DropTable("dbo.SizeTexts");
            DropTable("dbo.Sizes");
            DropTable("dbo.Prices");
            DropTable("dbo.Papers");
            DropTable("dbo.OrderFotos");
            DropTable("dbo.Fotos");
            DropTable("dbo.Orders");
            DropTable("dbo.Contacts");
        }
    }
}
