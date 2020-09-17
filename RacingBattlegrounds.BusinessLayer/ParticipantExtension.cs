using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.DataAccess.DataModels;

namespace RacingBattlegrounds.BusinessLayer.Utility
{
    public static class ParticipantExtension
    {
        public static RaceDetailsDTO ConvertToRaceDetailsDTO(this Participant participant)
        {
            return new RaceDetailsDTO()
            {
                CarName = participant.Car.Name,
                City = participant.Race.Track.City,
                CompletionTime = participant.CompletionTime,
                DriverName = participant.Driver.Name,
                EngineCapacity = participant.Race.EngineCapacity,
                TopSpeed = participant.TopSpeed,
                TrackLength = participant.Race.Track.Length,
                TrackName = participant.Race.Track.Name
            };
        }
    }
}
