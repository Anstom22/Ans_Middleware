using Ans_Middleware.Models;
using Microsoft.EntityFrameworkCore;

namespace Ans_Middleware.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options)
        {
            
        }
        public DbSet<Header> Headers{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=file::memory:?cache=shared");
            }
        }

        public void InitializeDatabase()
        {
            Database.EnsureCreated();
        }
    }
}
