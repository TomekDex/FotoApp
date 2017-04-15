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
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.FotoID);
            
            CreateTable(
                "dbo.OrderFotos",
                c => new
                    {
                        FotoID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FotoID, t.OrderID, t.Height, t.Length, t.TypeID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Papers", t => new { t.Height, t.Length, t.TypeID })
                .ForeignKey("dbo.Fotos", t => t.FotoID)
                .Index(t => t.FotoID)
                .Index(t => t.OrderID)
                .Index(t => new { t.Height, t.Length, t.TypeID });
            
            CreateTable(
                "dbo.Papers",
                c => new
                    {
                        Height = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        Availability = c.Int(),
                    })
                .PrimaryKey(t => new { t.Height, t.Length, t.TypeID })
                .ForeignKey("dbo.Sizes", t => new { t.Height, t.Length })
                .ForeignKey("dbo.Types", t => t.TypeID)
                .Index(t => new { t.Height, t.Length })
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Height = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Height, t.Length, t.TypeID, t.Quantity })
                .ForeignKey("dbo.Papers", t => new { t.Height, t.Length, t.TypeID })
                .Index(t => new { t.Height, t.Length, t.TypeID });
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Height = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Height, t.Length });
            
            CreateTable(
                "dbo.SizeTexts",
                c => new
                    {
                        Height = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        Language = c.String(nullable: false, maxLength: 5),
                        Text = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => new { t.Height, t.Length, t.Language })
                .ForeignKey("dbo.Languages", t => t.Language)
                .ForeignKey("dbo.Sizes", t => new { t.Height, t.Length })
                .Index(t => new { t.Height, t.Length })
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
                .ForeignKey("dbo.Types", t => t.TypeID)
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
            DropForeignKey("dbo.OrderFotos", "FotoID", "dbo.Fotos");
            DropForeignKey("dbo.SizeTexts", new[] { "Height", "Length" }, "dbo.Sizes");
            DropForeignKey("dbo.TypeTexts", "Language", "dbo.Languages");
            DropForeignKey("dbo.TypeTexts", "TypeID", "dbo.Types");
            DropForeignKey("dbo.Types", "Connect", "dbo.Types");
            DropForeignKey("dbo.Papers", "TypeID", "dbo.Types");
            DropForeignKey("dbo.SizeTexts", "Language", "dbo.Languages");
            DropForeignKey("dbo.Languages", "Base", "dbo.Languages");
            DropForeignKey("dbo.Papers", new[] { "Height", "Length" }, "dbo.Sizes");
            DropForeignKey("dbo.Prices", new[] { "Height", "Length", "TypeID" }, "dbo.Papers");
            DropForeignKey("dbo.OrderFotos", new[] { "Height", "Length", "TypeID" }, "dbo.Papers");
            DropForeignKey("dbo.OrderFotos", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Contacts", "OrderID", "dbo.Orders");
            DropIndex("dbo.Types", new[] { "Connect" });
            DropIndex("dbo.TypeTexts", new[] { "Language" });
            DropIndex("dbo.TypeTexts", new[] { "TypeID" });
            DropIndex("dbo.Languages", new[] { "Base" });
            DropIndex("dbo.SizeTexts", new[] { "Language" });
            DropIndex("dbo.SizeTexts", new[] { "Height", "Length" });
            DropIndex("dbo.Prices", new[] { "Height", "Length", "TypeID" });
            DropIndex("dbo.Papers", new[] { "TypeID" });
            DropIndex("dbo.Papers", new[] { "Height", "Length" });
            DropIndex("dbo.OrderFotos", new[] { "Height", "Length", "TypeID" });
            DropIndex("dbo.OrderFotos", new[] { "OrderID" });
            DropIndex("dbo.OrderFotos", new[] { "FotoID" });
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
