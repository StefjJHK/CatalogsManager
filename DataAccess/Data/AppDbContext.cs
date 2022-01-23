using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Catalog> Catalogs { get; set; } 
        public DbSet<Title> Titles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
        {
            
        }
    }
}
