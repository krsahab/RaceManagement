using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public class TrackDAO
    {
        public static List<Track> GetTracks()
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Tracks.ToList();
            }
        }
        public static Track GetTrackDetails(int Id)
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Tracks.Find(Id);
            }
        }
        public static void UpdateTrackDetails(Track track)
        {
            using (var context = new ApplicationDBContext())
            {
                context.Entry(track).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void AddTrack(Track track)
        {
            using (var context = new ApplicationDBContext())
            {
                context.Tracks.Add(track);
                context.SaveChanges();
            }
        }
        public static void DeleteTrack(int Id)
        {
            using (var context = new ApplicationDBContext())
            {
                Track track = context.Tracks.Find(Id);
                context.Tracks.Remove(track);
                context.SaveChanges();
            }
        }
    }
}
