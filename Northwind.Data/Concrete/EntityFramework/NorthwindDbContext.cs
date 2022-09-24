using Microsoft.EntityFrameworkCore;
using Northwind.Entity.Concrete;

namespace Northwind.Data.Concrete.EntityFramework
{
    public class NorthwindDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Northwind;Trusted_Connection=true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Ignore(t => t.Id);
            modelBuilder.Entity<Product>().Ignore(t => t.Id);            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
