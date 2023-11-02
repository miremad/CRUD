using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("AuthorDb");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
