namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Texts", "Language", "dbo.Languages");
            DropForeignKey("dbo.Texts", "Paperss_PaperID", "dbo.Papers");
            DropIndex("dbo.Texts", new[] { "Language" });
            DropIndex("dbo.Texts", new[] { "Paperss_PaperID" });
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        PaperID = c.Int(nullable: false),
                        Language = c.String(nullable: false, maxLength: 5),
                        Size = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => new { t.PaperID, t.Language })
                .ForeignKey("dbo.Languages", t => t.Language)
                .ForeignKey("dbo.Papers", t => t.PaperID)
                .Index(t => t.PaperID)
                .Index(t => t.Language);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        PaperID = c.Int(nullable: false),
                        Language = c.String(nullable: false, maxLength: 5),
                        type = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => new { t.PaperID, t.Language })
                .ForeignKey("dbo.Languages", t => t.Language)
                .ForeignKey("dbo.Papers", t => t.PaperID)
                .Index(t => t.PaperID)
                .Index(t => t.Language);
            
            DropColumn("dbo.Papers", "Size");
            DropColumn("dbo.Papers", "Type");
            DropTable("dbo.Texts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Texts",
                c => new
                    {
                        TextID = c.Int(nullable: false),
                        Language = c.String(nullable: false, maxLength: 5),
                        Text = c.String(nullable: false, maxLength: 20),
                        Paperss_PaperID = c.Int(),
                    })
                .PrimaryKey(t => new { t.TextID, t.Language });
            
            AddColumn("dbo.Papers", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Papers", "Size", c => c.Int(nullable: false));
            DropForeignKey("dbo.Types", "PaperID", "dbo.Papers");
            DropForeignKey("dbo.Sizes", "PaperID", "dbo.Papers");
            DropForeignKey("dbo.Types", "Language", "dbo.Languages");
            DropForeignKey("dbo.Sizes", "Language", "dbo.Languages");
            DropIndex("dbo.Types", new[] { "Language" });
            DropIndex("dbo.Types", new[] { "PaperID" });
            DropIndex("dbo.Sizes", new[] { "Language" });
            DropIndex("dbo.Sizes", new[] { "PaperID" });
            DropTable("dbo.Types");
            DropTable("dbo.Sizes");
            CreateIndex("dbo.Texts", "Paperss_PaperID");
            CreateIndex("dbo.Texts", "Language");
            AddForeignKey("dbo.Texts", "Paperss_PaperID", "dbo.Papers", "PaperID");
            AddForeignKey("dbo.Texts", "Language", "dbo.Languages", "Language");
        }
    }
}
