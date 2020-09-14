using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RacingBattlegrounds.UI.Models.ViewModel
{
    public class ParticipantViewModel
    {
        [Display(Name = "Participant Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Driver Id")]
        public int Driver_Id { get; set; }
        public SelectList Drivers { get; set; }
        [Required]
        [Display(Name = "Race Id")]
        public int Race_Id { get; set; }
        public SelectList Races { get; set; }
        [Required]
        [Display(Name = "Car Id")]
        public int Car_Id { get; set; }
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