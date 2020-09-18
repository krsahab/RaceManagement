using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public static class ParticipantDAO
    {
        private static readonly ApplicationDBContext context;
        static ParticipantDAO()
        {
            context = new ApplicationDBContext();
        }
        public static List<Participant> GetParticipants()
        {
            return context.Participants
                .Include(x => x.Driver)
                .Include(x => x.Car)
                .Include(x => x.Race)
                .Include(x => x.Race.Track).ToList();
        }
        public static Participant GetParticipantDetails(int Id)
        {
            return context.Participants
                .Include(x => x.Driver)
                .Include(x => x.Car)
                .Include(x => x.Race)
                .Include(x => x.Race.Track)
                .FirstOrDefault(x => x.Id == Id);
        }
        public static void UpdateParticipantDetails(Participant Participant)
        {
            var participant = context.Participants
                .Include(x => x.Driver)
                .Include(x => x.Car)
                .Include(x => x.Race)
                .FirstOrDefault(x => x.Id == Participant.Id);
            context.Entry(participant).CurrentValues.SetValues(Participant);
            participant.Driver = Participant.Driver;
            participant.Car = Participant.Car;
            participant.Race = Participant.Race;
            context.SaveChanges();
        }
        public static void AddParticipant(Participant Participant)
        {
            context.Participants.Add(Participant);
            context.SaveChanges();
        }
        public static void DeleteParticipant(int Id)
        {
            Participant Participant = context.Participants.Find(Id);
            context.Participants.Remove(Participant);
            context.SaveChanges();
        }
    }
}
