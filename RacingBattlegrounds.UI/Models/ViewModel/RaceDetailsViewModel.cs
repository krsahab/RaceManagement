using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RacingBattlegrounds.UI.Models.ViewModel
{
    public class RaceDetailsViewModel
    {
        [Display(Name = "City Name")]
        public string City { get; set; }
        [Display(Name = "Track Name")]
        public string TrackName { get; set; }
        [Display(Name = "Track Length")]
        public int TrackLength { get; set; }
        [Display(Name = "Engine Capacity")]
        public int EngineCapacity { get; set; }
        [Display(Name = "Car Name")]
        public string CarName { get; set; }
        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }
        [Display(Name = "Top Speed")]
        public float TopSpeed { get; set; }
        [Display(Name = "Completion Time")]
        public int CompletionTime { get; set; }
    }
}