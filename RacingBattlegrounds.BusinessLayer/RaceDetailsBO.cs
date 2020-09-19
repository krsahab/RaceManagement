using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.DataAccess.DAO;
using System.Collections.Generic;
using System.Linq;

namespace RacingBattlegrounds.BusinessLayer
{
    public class RaceDetailsBO
    {
        public IEnumerable<RaceDetailsDTO> GetRaceDetails()
        {
            ParticipantBO participantBO = new ParticipantBO();
            var result = RaceDAO.GetRaces()
                .Select(x => new { race = x, winner = participantBO.GetParticipants().Where(y => y.RaceId == x.Id && y.IsWinner) });
            var raceDetails = new List<RaceDetailsDTO>();
            foreach (var race in result)
            {
                RaceDetailsDTO raceDetailsDTO = new RaceDetailsDTO
                {
                    Name = race.race.Name,
                    TrackName = race.race.Track.Name,
                    EngineCapacity = race.race.EngineCapacity,
                    City = race.race.Track.City,
                    TrackLength = race.race.Track.Length,
                    Winners = race.winner?.ToList()
                };
                raceDetails.Add(raceDetailsDTO);
            }
            return raceDetails;
        }
    }
}
