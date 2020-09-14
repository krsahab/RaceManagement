using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public static class RaceDetailsDAO
    {
        public static List<Participant> GetRaceDetails()
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Participants
                    .Include(x => x.Car)
                    .Include(x => x.Driver)
                    .Include(x => x.Race)
                    .Include(x => x.Race.Track)
                    .Where(x => x.IsWinner == true)
                    .OrderByDescending(x => x.TopSpeed).ToList();
            }
        }
    }
}
