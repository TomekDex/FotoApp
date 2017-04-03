namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Mail", c => c.String(maxLength: 255));
            DropColumn("dbo.Fotos", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fotos", "Path", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "Mail", c => c.String());
        }
    }
}
