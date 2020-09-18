using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public static class RaceDAO
    {
        private static readonly ApplicationDBContext context;
        static RaceDAO()
        {
            context = new ApplicationDBContext();
        }
        public static List<Race> GetRaces()
        {
            return context.Races.Include(x => x.Track).ToList();
        }
        public static Race GetRaceDetails(int Id)
        {
            return context.Races.Include(x => x.Track).FirstOrDefault(x => x.Id == Id);
        }
        public static void UpdateRaceDetails(Race race)
        {
            var Race = context.Races.Include(x => x.Track).FirstOrDefault(x => x.Id == race.Id);
            context.Entry(Race).CurrentValues.SetValues(race);
            Race.Track = race.Track;
            context.SaveChanges();
        }
        public static void AddRace(Race race)
        {
            context.Races.Add(race);
            context.SaveChanges();
        }
        public static void DeleteRace(int Id)
        {
            Race race = context.Races.Find(Id);
            context.Races.Remove(race);
            context.SaveChanges();
        }
    }
}
