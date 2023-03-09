using Microsoft.EntityFrameworkCore;

namespace Web_API.Models
{
    public class ThyContext : DbContext
    {
        public ThyContext(DbContextOptions<ThyContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<ThyFirstClass> ThyFirstClasses { get; set; } = null;
    }
}
