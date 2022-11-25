using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Models
{
    public class TeamContext : DbContext
    {
        public DbSet<Team> Team { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MatchDataManagerDatabase.sqlite");
        }
    }
}
