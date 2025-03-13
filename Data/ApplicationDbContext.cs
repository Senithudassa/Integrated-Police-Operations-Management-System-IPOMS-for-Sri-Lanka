using Microsoft.EntityFrameworkCore;
using testproj.Controllers;
using testproj.Models;


namespace testproj.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }  // Admin Table

        public DbSet<RobberyReport> RobberyReports { get; set; }

        public DbSet<Violation> Violations { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Accident> Accidents { get; set; }

        public DbSet<CriminalActivity> CriminalActivities { get; set; }

        public DbSet<NarcoticActivity> NarcoticActivities { get; set; }

    }

}


