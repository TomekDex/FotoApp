namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Papers", new[] { "Types_TypeID", "Types_Language" }, "dbo.Types");
            DropForeignKey("dbo.Papers", "SizeID", "dbo.Sizes");
            DropIndex("dbo.Papers", new[] { "SizeID" });
            RenameColumn(table: "dbo.Types", name: "Types_TypeID", newName: "Papers_PaperID");
            DropPrimaryKey("dbo.Sizes");
            AddColumn("dbo.Papers", "Sizes_SizeID", c => c.Int());
            AddColumn("dbo.Papers", "Sizes_Language", c => c.String(maxLength: 5));
            AddColumn("dbo.Types", "Paperss_PaperID", c => c.Int());
            AlterColumn("dbo.Sizes", "SizeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Sizes", "Language", c => c.String(nullable: false, maxLength: 5));
            AddPrimaryKey("dbo.Sizes", new[] { "SizeID", "Language" });
            CreateIndex("dbo.Papers", new[] { "Sizes_SizeID", "Sizes_Language" });
            CreateIndex("dbo.Sizes", "SizeID");
            CreateIndex("dbo.Types", "Paperss_PaperID");
            CreateIndex("dbo.Types", "Papers_PaperID");
            AddForeignKey("dbo.Types", "Paperss_PaperID", "dbo.Papers", "PaperID");
            AddForeignKey("dbo.Types", "Papers_PaperID", "dbo.Papers", "PaperID");
            AddForeignKey("dbo.Papers", new[] { "Sizes_SizeID", "Sizes_Language" }, "dbo.Sizes", new[] { "SizeID", "Language" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Papers", new[] { "Sizes_SizeID", "Sizes_Language" }, "dbo.Sizes");
            DropForeignKey("dbo.Types", "Papers_PaperID", "dbo.Papers");
            DropForeignKey("dbo.Types", "Paperss_PaperID", "dbo.Papers");
            DropIndex("dbo.Types", new[] { "Papers_PaperID" });
            DropIndex("dbo.Types", new[] { "Paperss_PaperID" });
            DropIndex("dbo.Sizes", new[] { "SizeID" });
            DropIndex("dbo.Papers", new[] { "Sizes_SizeID", "Sizes_Language" });
            DropPrimaryKey("dbo.Sizes");
            AlterColumn("dbo.Sizes", "Language", c => c.String());
            AlterColumn("dbo.Sizes", "SizeID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Types", "Paperss_PaperID");
            DropColumn("dbo.Papers", "Sizes_Language");
            DropColumn("dbo.Papers", "Sizes_SizeID");
            AddPrimaryKey("dbo.Sizes", "SizeID");
            RenameColumn(table: "dbo.Types", name: "Papers_PaperID", newName: "Types_TypeID");
            CreateIndex("dbo.Papers", "SizeID");
            AddForeignKey("dbo.Papers", "SizeID", "dbo.Sizes", "SizeID", cascadeDelete: true);
            AddForeignKey("dbo.Papers", new[] { "Types_TypeID", "Types_Language" }, "dbo.Types", new[] { "TypeID", "Language" });
        }
    }
}
