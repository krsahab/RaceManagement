using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public class ParticipantDAO
    {
        public static List<Participant> GetParticipants()
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Participants
                    .Include(x => x.Driver)
                    .Include(x => x.Car)
                    .Include(x => x.Race)
                    .Include(x => x.Race.Track).ToList();
            }
        }
        public static Participant GetParticipantDetails(int Id)
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Participants
                    .Include(x => x.Driver)
                    .Include(x => x.Car)
                    .Include(x => x.Race)
                    .Include(x => x.Race.Track)
                    .FirstOrDefault(x => x.Id == Id);
            }
        }
        public static void UpdateParticipantDetails(Participant Participant)
        {
            using (var context = new ApplicationDBContext())
            {
                Participant.Race.Track = null;
                var participant = context.Participants.FirstOrDefault(x => x.Id == Participant.Id);
                context.Entry(participant).CurrentValues.SetValues(Participant);
                participant.Driver = Participant.Driver;
                participant.Car = Participant.Car;
                participant.Race = Participant.Race;
                context.Entry(participant.Driver).State = EntityState.Unchanged;
                context.Entry(participant.Race).State = EntityState.Unchanged;
                context.Entry(participant.Car).State = EntityState.Unchanged;
                context.SaveChanges();
            }
        }
        public static void AddParticipant(Participant Participant)
        {
            using (var context = new ApplicationDBContext())
            {
                Participant.Race.Track = null;
                context.Participants.Add(Participant);
                context.Entry(Participant.Driver).State = EntityState.Unchanged;
                context.Entry(Participant.Race).State = EntityState.Unchanged;
                context.Entry(Participant.Car).State = EntityState.Unchanged;
                context.SaveChanges();
            }
        }
        public static void DeleteParticipant(int Id)
        {
            using (var context = new ApplicationDBContext())
            {
                Participant Participant = context.Participants.Find(Id);
                context.Participants.Remove(Participant);
                context.SaveChanges();
            }
        }
    }
}
