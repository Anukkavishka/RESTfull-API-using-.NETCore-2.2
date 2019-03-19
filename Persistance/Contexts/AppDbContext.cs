using Microsoft.EntityFrameworkCore;
using SuperMarket.Domain.Models;
/**
Entity Framework is a code first approach framework which is defined by the Mocrosoft.!-- you could define the Domain models in POCO objects 
and then  EF will be the ORM to map and create respective database entities.!--

*/

namespace SuperMarket.Persistence.Contexts
{
    public class AppDbContext : DbContext //this class is used by EF for ORM mapping
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        /*
        we have to map the models’ properties to the respective table columns, specifying which properties are primary keys,
         which are foreign keys, the column types, etc. We can do this overriding the method OnModelCreating, 
         using a feature called Fluent API to specify the database mapping. Change the AppDbContext class as follows:
         */

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Category");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
                new Category { Id = 101, Name = "Dairy" },
                new Category { Id = 102, Name = "Breads" },
                new Category { Id = 103, Name = "Fisheries" }

            );

            builder.Entity<Product>().ToTable("Product");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
        }

    }
}