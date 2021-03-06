﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RacingBattlegrounds.UI.Models.ViewModel
{
    public class RaceViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Track Id")]
        public int TrackId { get; set; }
        [Display(Name = "Track Name")]
        public string TrackName { get; set; }
        public SelectList Tracks { get; set; }
        [Required]
        [Display(Name = "Engine Capacity")]
        public int EngineCapacity { get; set; }
    }
}