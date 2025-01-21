using Microsoft.EntityFrameworkCore;

using testproj.Models;

namespace testproj.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }  // Admin Table
    }

}


