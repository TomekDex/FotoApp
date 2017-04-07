namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SizeTexts", name: "TextID", newName: "SizeID");
            RenameColumn(table: "dbo.TypeTexts", name: "TextID", newName: "TypeID");
            RenameIndex(table: "dbo.SizeTexts", name: "IX_TextID", newName: "IX_SizeID");
            RenameIndex(table: "dbo.TypeTexts", name: "IX_TextID", newName: "IX_TypeID");
            DropColumn("dbo.Sizes", "TextID");
            DropColumn("dbo.Types", "TextID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Types", "TextID", c => c.Int(nullable: false));
            AddColumn("dbo.Sizes", "TextID", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.TypeTexts", name: "IX_TypeID", newName: "IX_TextID");
            RenameIndex(table: "dbo.SizeTexts", name: "IX_SizeID", newName: "IX_TextID");
            RenameColumn(table: "dbo.TypeTexts", name: "TypeID", newName: "TextID");
            RenameColumn(table: "dbo.SizeTexts", name: "SizeID", newName: "TextID");
        }
    }
}
