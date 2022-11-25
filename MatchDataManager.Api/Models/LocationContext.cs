using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Models
{
    public class LocationContext : DbContext
    {
        public DbSet<Location> Location { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MatchDataManagerDatabase.sqlite");
        }
    }
}
