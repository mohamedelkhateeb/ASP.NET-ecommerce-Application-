using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
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
        }
    }
}
