using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacingBattlegrounds.DataAccess.DataModels;
using System.Data.Entity;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public static class RaceDetailsDAO
    {
        public static List<Participants> GetRaceDetails()
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Participants
                    .Include(x => x.Car)
                    .Include(x => x.Driver)
                    .Include(x => x.Race)
                    .Include(x=>x.Race.Track)
                    .Where(x => x.IsWinner == true)
                    .OrderByDescending(x => x.TopSpeed).ToList();
            }
        }
    }
}
