using Microsoft.EntityFrameworkCore;
using testproj.Models; // Ensure this matches your namespace

namespace testproj.Data // Ensure this matches your project namespace
{
    public class CriminalActivityContext : DbContext
    {
        public CriminalActivityContext(DbContextOptions<CriminalActivityContext> options)
            : base(options)
        {
        }

        public DbSet<CriminalActivity> CriminalActivities { get; set; }
    }
}

