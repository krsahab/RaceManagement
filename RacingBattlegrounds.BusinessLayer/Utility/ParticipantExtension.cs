using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacingBattlegrounds.DataAccess.DataModels;
using RacingBattlegrounds.BusinessLayer.DTO;

namespace RacingBattlegrounds.BusinessLayer.Utility
{
    public static class ParticipantExtension
    {
        public static RaceDetailsDTO ConvertToRaceDetailsDTO(this Participants participant)
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
