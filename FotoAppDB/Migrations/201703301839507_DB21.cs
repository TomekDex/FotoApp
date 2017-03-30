namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrdersFotos", "OrderID", "dbo.Orders");
            DropPrimaryKey("dbo.OrdersFotos");
            AddPrimaryKey("dbo.OrdersFotos", new[] { "OrderID", "FotoID" });
            CreateIndex("dbo.OrdersFotos", "FotoID");
            AddForeignKey("dbo.OrdersFotos", "FotoID", "dbo.Fotos", "FotoID", cascadeDelete: true);
            AddForeignKey("dbo.OrdersFotos", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdersFotos", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrdersFotos", "FotoID", "dbo.Fotos");
            DropIndex("dbo.OrdersFotos", new[] { "FotoID" });
            DropPrimaryKey("dbo.OrdersFotos");
            AddPrimaryKey("dbo.OrdersFotos", "OrderID");
            AddForeignKey("dbo.OrdersFotos", "OrderID", "dbo.Orders", "OrderID");
        }
    }
}
