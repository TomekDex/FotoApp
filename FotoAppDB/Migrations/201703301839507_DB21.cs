namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrdersFotos", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrdersFotos", new[] { "OrderID" });
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        SizeID = c.Int(nullable: false, identity: true),
                        Language = c.String(),
                        Text = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.SizeID);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeID = c.Int(nullable: false),
                        Language = c.String(nullable: false, maxLength: 5),
                        Text = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => new { t.TypeID, t.Language });
            
            AddColumn("dbo.Papers", "SizeID", c => c.Int(nullable: false));
            AddColumn("dbo.Papers", "TypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Papers", "Types_TypeID", c => c.Int());
            AddColumn("dbo.Papers", "Types_Language", c => c.String(maxLength: 5));
            CreateIndex("dbo.Papers", "SizeID");
            CreateIndex("dbo.Papers", new[] { "Types_TypeID", "Types_Language" });
            AddForeignKey("dbo.Papers", "SizeID", "dbo.Sizes", "SizeID", cascadeDelete: true);
            AddForeignKey("dbo.Papers", new[] { "Types_TypeID", "Types_Language" }, "dbo.Types", new[] { "TypeID", "Language" });
            DropColumn("dbo.Papers", "Size");
            DropColumn("dbo.Papers", "Paper");
            DropTable("dbo.OrdersFotos");
            DropTable("dbo.Texts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Texts",
                c => new
                    {
                        TextID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.TextID);
            
            CreateTable(
                "dbo.OrdersFotos",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        FotoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            AddColumn("dbo.Papers", "Paper", c => c.Int(nullable: false));
            AddColumn("dbo.Papers", "Size", c => c.Int(nullable: false));
            DropForeignKey("dbo.Papers", new[] { "Types_TypeID", "Types_Language" }, "dbo.Types");
            DropForeignKey("dbo.Papers", "SizeID", "dbo.Sizes");
            DropIndex("dbo.Papers", new[] { "Types_TypeID", "Types_Language" });
            DropIndex("dbo.Papers", new[] { "SizeID" });
            DropColumn("dbo.Papers", "Types_Language");
            DropColumn("dbo.Papers", "Types_TypeID");
            DropColumn("dbo.Papers", "TypeID");
            DropColumn("dbo.Papers", "SizeID");
            DropTable("dbo.Types");
            DropTable("dbo.Sizes");
            CreateIndex("dbo.OrdersFotos", "OrderID");
            AddForeignKey("dbo.OrdersFotos", "OrderID", "dbo.Orders", "OrderID");
        }
    }
}
