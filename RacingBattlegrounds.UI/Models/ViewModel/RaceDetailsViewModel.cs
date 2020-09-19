using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RacingBattlegrounds.UI.Models.ViewModel
{
    public class RaceDetailsViewModel
    {
        public string Name { get; set; }
        [Display(Name = "City Name")]
        public string City { get; set; }
        [Display(Name = "Track Name")]
        public string TrackName { get; set; }
        [Display(Name = "Track Length")]
        public int TrackLength { get; set; }
        [Display(Name = "Engine Capacity")]
        public int EngineCapacity { get; set; }
        public IEnumerable<ParticipantViewModel> Winners { get; set; }
    }
}