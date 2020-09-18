using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RacingBattlegrounds.UI.Models.ViewModel
{
    public class ParticipantViewModel
    {
        [Display(Name = "Participant Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Driver")]
        public int DriverId { get; set; }
        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }
        public SelectList Drivers { get; set; }
        [Required]
        [Display(Name = "Race")]
        public int RaceId { get; set; }
        [Display(Name = "Race Name")]
        public string RaceName { get; set; }
        public SelectList Races { get; set; }
        [Required]
        [Display(Name = "Car")]
        public int CarId { get; set; }
        [Display(Name = "Car name")]
        public string CarName { get; set; }
        public SelectList Cars { get; set; }
        [Required]
        [Display(Name = "Top Speed")]
        public float TopSpeed { get; set; }
        [Required]
        [Display(Name = "Completion Time")]
        public int CompletionTime { get; set; }
        [Display(Name = "Winner")]
        public bool IsWinner { get; set; } = false;
    }
}