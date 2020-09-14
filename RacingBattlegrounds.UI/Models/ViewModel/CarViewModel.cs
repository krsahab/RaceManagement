using System;
using System.ComponentModel.DataAnnotations;

namespace RacingBattlegrounds.UI.Models.ViewModel
{
    public class CarViewModel
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Engine Capacity")]
        public int EngineCapacity { get; set; }
    }
}