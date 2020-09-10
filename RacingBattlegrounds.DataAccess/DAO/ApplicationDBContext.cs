using RacingBattlegrounds.DataAccess.DataModels;
using System.Data.Entity;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
            : base("name=RaceConnectionString")
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}
