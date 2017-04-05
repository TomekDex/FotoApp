namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Texts", name: "Papers_PaperID", newName: "Paperss_PaperID");
            RenameIndex(table: "dbo.Texts", name: "IX_Papers_PaperID", newName: "IX_Paperss_PaperID");
            AddColumn("dbo.Papers", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Papers", "Paper");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Papers", "Paper", c => c.Int(nullable: false));
            DropColumn("dbo.Papers", "Type");
            RenameIndex(table: "dbo.Texts", name: "IX_Paperss_PaperID", newName: "IX_Papers_PaperID");
            RenameColumn(table: "dbo.Texts", name: "Paperss_PaperID", newName: "Papers_PaperID");
        }
    }
}
