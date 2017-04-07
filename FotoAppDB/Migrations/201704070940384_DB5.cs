namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SizeTexts", "Language", "dbo.Languages");
            DropForeignKey("dbo.TypeTexts", "Language", "dbo.Languages");
            DropIndex("dbo.SizeTexts", new[] { "Language" });
            DropIndex("dbo.TypeTexts", new[] { "Language" });
            DropPrimaryKey("dbo.SizeTexts");
            DropPrimaryKey("dbo.Languages");
            DropPrimaryKey("dbo.TypeTexts");
            AlterColumn("dbo.SizeTexts", "Language", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.SizeTexts", "Text", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Languages", "Language", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.TypeTexts", "Language", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.TypeTexts", "Text", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.SizeTexts", new[] { "SizeID", "Language" });
            AddPrimaryKey("dbo.Languages", "Language");
            AddPrimaryKey("dbo.TypeTexts", new[] { "TypeID", "Language" });
            CreateIndex("dbo.SizeTexts", "Language");
            CreateIndex("dbo.TypeTexts", "Language");
            AddForeignKey("dbo.SizeTexts", "Language", "dbo.Languages", "Language");
            AddForeignKey("dbo.TypeTexts", "Language", "dbo.Languages", "Language");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TypeTexts", "Language", "dbo.Languages");
            DropForeignKey("dbo.SizeTexts", "Language", "dbo.Languages");
            DropIndex("dbo.TypeTexts", new[] { "Language" });
            DropIndex("dbo.SizeTexts", new[] { "Language" });
            DropPrimaryKey("dbo.TypeTexts");
            DropPrimaryKey("dbo.Languages");
            DropPrimaryKey("dbo.SizeTexts");
            AlterColumn("dbo.TypeTexts", "Text", c => c.String());
            AlterColumn("dbo.TypeTexts", "Language", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Languages", "Language", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.SizeTexts", "Text", c => c.String());
            AlterColumn("dbo.SizeTexts", "Language", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.TypeTexts", new[] { "TypeID", "Language" });
            AddPrimaryKey("dbo.Languages", "Language");
            AddPrimaryKey("dbo.SizeTexts", new[] { "SizeID", "Language" });
            CreateIndex("dbo.TypeTexts", "Language");
            CreateIndex("dbo.SizeTexts", "Language");
            AddForeignKey("dbo.TypeTexts", "Language", "dbo.Languages", "Language");
            AddForeignKey("dbo.SizeTexts", "Language", "dbo.Languages", "Language");
        }
    }
}
