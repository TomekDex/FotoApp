namespace FotoAppDB
{
    using FotoAppDB.DBModel;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FotoAppDbContext : DbContext
    {
        // Your context has been configured to use a 'FotoAppDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FotoAppDB.FotoAppDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FotoAppDbContext' 
        // connection string in the application configuration file.
        public FotoAppDbContext()
            : base("name=FotoAppDbContext")
        {
        }
        public DbSet<Contacts> Contact { get; set; }
        public DbSet<Discounts> Discount { get; set; }
        public DbSet<Fotos> Foto { get; set; }
        public DbSet<Orders> Order { get; set; }
        public DbSet<Papers> Paper { get; set; }
        public DbSet<Sizes> Text { get; set; }
        public DbSet<Types> Type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PapersConf());
            modelBuilder.Entity<Papers>()
        .HasMany<Sizes>(s => s.Sizes)
        .WithRequired(p => p.Paperss)
        .HasForeignKey(p => p.SizeID);
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }



    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}