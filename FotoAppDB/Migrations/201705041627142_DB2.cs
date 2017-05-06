namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "OrderID", "dbo.Orders");
            AlterColumn("dbo.Contacts", "TelephoneNumber", c => c.String(maxLength: 20));
            AddForeignKey("dbo.Contacts", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "OrderID", "dbo.Orders");
            AlterColumn("dbo.Contacts", "TelephoneNumber", c => c.String());
            AddForeignKey("dbo.Contacts", "OrderID", "dbo.Orders", "OrderID");
        }
    }
}
