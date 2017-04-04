namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Texts", new[] { "Paperss_PaperID" });
            AlterColumn("dbo.Texts", "Paperss_PaperID", c => c.Int());
            CreateIndex("dbo.Texts", "Paperss_PaperID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Texts", new[] { "Paperss_PaperID" });
            AlterColumn("dbo.Texts", "Paperss_PaperID", c => c.Int(nullable: false));
            CreateIndex("dbo.Texts", "Paperss_PaperID");
        }
    }
}
