namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Area = c.String(nullable: false, maxLength: 10),
                        Type = c.String(nullable: false, maxLength: 10),
                        LogID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Value = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => new { t.Area, t.Type, t.LogID });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logs");
        }
    }
}
