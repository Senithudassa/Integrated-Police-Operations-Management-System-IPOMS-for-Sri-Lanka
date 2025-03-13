using Microsoft.EntityFrameworkCore;
using testproj.Models;
using testproj.Models;

namespace testproj.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<NarcoticActivity> NarcoticActivities { get; set; } // DB table
    }
}

