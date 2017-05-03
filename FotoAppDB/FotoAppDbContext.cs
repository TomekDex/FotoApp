namespace FotoAppDB
{
    using FotoAppDB.DBModel;
    using System.Data.Entity;

    public class FotoAppDbContext : DbContext
    {
        // Your context has been configured to use a 'FotoAppDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FotoAppDB.FotoAppDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FotoAppDbContext' 
        // connection string in the application configuration file.
        public FotoAppDbContext(string nameOrConnectionString)
        : base(nameOrConnectionString)
        {
        }

        public FotoAppDbContext()
            : base("name=FotoAppDbContext")
        {
        }
        public DbSet<Contacts> Contact { get; set; }
        public DbSet<Prices> Price { get; set; }
        public DbSet<OrderFotos> OrderFoto { get; set; }
        public DbSet<Orders> Order { get; set; }
        public DbSet<Papers> Paper { get; set; }
        public DbSet<Sizes> Size { get; set; }
        public DbSet<Types> Type { get; set; }
        public DbSet<TypeTexts> TypeText { get; set; }
        public DbSet<SizeTexts> SizeText { get; set; }
        public DbSet<Languages> Language { get; set; }
        public DbSet<Fotos> Foto { get; set; }
        public DbSet<Settings> Setting { get; set; }
        public DbSet<Logs> Log { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Papers>().HasKey(p => new { p.Height, p.Width, p.TypeID });
            modelBuilder.Entity<Prices>().HasKey(p => new { p.Height, p.Width, p.TypeID, p.Quantity });
            modelBuilder.Entity<OrderFotos>().HasKey(f => new { f.FotoID, f.Height, f.Width, f.TypeID });
            modelBuilder.Entity<Sizes>().HasKey(s => new { s.Height, s.Width });
            modelBuilder.Entity<Papers>()
                .HasMany(p => p.Prices)
                .WithRequired(p => p.Papers)
                .HasForeignKey(p => new { p.Height, p.Width, p.TypeID })
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Papers>()
                .HasMany(p => p.OrderFotos)
                .WithRequired(p => p.Papers)
                .HasForeignKey(p => new { p.Height, p.Width, p.TypeID })
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Sizes>()
                .HasMany(p => p.SizeTexts)
                .WithRequired(s => s.Sizes)
                .HasForeignKey(p => new { p.Height, p.Width })
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Types>()
                .HasMany(p => p.TypeTexts)
                .WithRequired(s => s.Types)
                .HasForeignKey(p => p.TypeID)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Sizes>()
                .HasMany(t => t.Papers)
                .WithRequired(s => s.Sizes)
                .HasForeignKey(s => new { s.Height, s.Width })
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Types>()
                .HasMany(t => t.Papers)
                .WithRequired(s => s.Types)
                .HasForeignKey(s => s.TypeID)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Languages>()
                .HasMany(p => p.SizeTexts)
                .WithRequired(s => s.Languages)
                .HasForeignKey(p => p.Language)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Languages>()
                .HasMany(p => p.TypeTexts)
                .WithRequired(s => s.Languages)
                .HasForeignKey(p => p.Language)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Fotos>()
                .HasMany(o => o.OrderFotos)
                .WithRequired(f => f.Fotos)
                .HasForeignKey(o => o.FotoID)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Languages>()
                .HasMany(l => l.Languages1)
                .WithOptional(l => l.Languages2)
                .HasForeignKey(l => l.Base)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Types>()
                .HasMany(l => l.Types1)
                .WithOptional(l => l.Types2)
                .HasForeignKey(l => l.Connect)
                .WillCascadeOnDelete(false);
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