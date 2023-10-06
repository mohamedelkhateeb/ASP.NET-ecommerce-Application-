using Bulky.Models.Models;
using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // Dealing With Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action 1", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Action 2", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Action 3", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Action 4", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Action 5", DisplayOrder = 5 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Title 1",
                    Author = "Author One",
                    Description = "Description one",
                    ISPN = "ISPN i",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 80,
                    Price100 = 70,
                    CategoryId = 1,
                    ImageUrl = ""
                });
        }
    }
}
