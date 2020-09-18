using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public static class TrackDAO
    {
        private static readonly ApplicationDBContext context;
        static TrackDAO()
        {
            context = new ApplicationDBContext();
        }
        public static List<Track> GetTracks()
        {
            return context.Tracks.ToList();
        }
        public static Track GetTrackDetails(int Id)
        {
            return context.Tracks.Find(Id);
        }
        public static void UpdateTrackDetails(Track track)
        {
            context.Entry(track).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public static void AddTrack(Track track)
        {
            context.Tracks.Add(track);
            context.SaveChanges();
        }
        public static void DeleteTrack(int Id)
        {
            Track track = context.Tracks.Find(Id);
            context.Tracks.Remove(track);
            context.SaveChanges();
        }
    }
}
