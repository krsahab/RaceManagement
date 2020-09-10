using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacingBattlegrounds.DataAccess.DataModels;
using System.Data.Entity;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public class RaceDAO
    {
        public static List<Race> GetRaces()
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Races.Include(x=>x.Track).ToList();
            }
        }
        public static Race GetRaceDetails(int Id)
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Races.Include(x => x.Track).FirstOrDefault(x=>x.Id==Id);
            }
        }
        public static void UpdateRaceDetails(Race race)
        {
            using (var context = new ApplicationDBContext())
            {
                context.Entry(race).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void AddRace(Race race)
        {
            using (var context = new ApplicationDBContext())
            {
                context.Races.Add(race);
                context.SaveChanges();
            }
        }
        public static void DeleteRace(int Id)
        {
            using (var context = new ApplicationDBContext())
            {
                Race race = context.Races.Find(Id);
                context.Races.Remove(race);
                context.SaveChanges();
            }
        }
    }
}
