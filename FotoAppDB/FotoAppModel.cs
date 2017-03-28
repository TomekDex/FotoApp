namespace FotoAppDB
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FotoAppModel : DbContext
    {
        // Your context has been configured to use a 'FotoAppModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FotoAppDB.FotoAppModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FotoAppModel' 
        // connection string in the application configuration file.
        public FotoAppModel()
            : base("name=FotoAppModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class Fotos
    {
        public int FotoID { get; set; }
        public int OrderID { get; set; }
        public int PaperID { get; set; }
        public int Quantity { get; set; }
        public string URL { get; set; }
    }
    public class Papers
    {
        public int PaperID { get; set; }
        public string Size { get; set; }
        public string Paper { get; set; }
        public double Cost { get; set; }
    }
    public class Discounts
    {
        public int FotoID { get; set; }
        public int PaperID { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
    }
    public class Orders
    {
        public int OrderID { get; set; }
        public double Description { get; set; }
        public DateTime Data { get; set; }
    }
    public class OrdersFotos
    {
        public int OrderID { get; set; }
        public int FotoID { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}