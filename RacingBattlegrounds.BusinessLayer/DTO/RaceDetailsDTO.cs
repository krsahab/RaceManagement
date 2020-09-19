using System.Collections.Generic;

namespace RacingBattlegrounds.BusinessLayer.DTO
{
    public class RaceDetailsDTO
    {
        public string Name { get; set; }
        public string TrackName { get; set; }
        public int EngineCapacity { get; set; }
        public string City { get; set; }
        public int TrackLength { get; set; }
        public List<ParticipantDTO> Winners { get; set; }
    }
}
