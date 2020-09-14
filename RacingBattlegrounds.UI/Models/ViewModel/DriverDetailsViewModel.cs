using System.ComponentModel.DataAnnotations;

namespace RacingBattlegrounds.UI.Models.ViewModel
{
    public class DriverDetailsViewModel
    {
        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }
        [Display(Name = "Race Participated")]
        public int RaceParticipated { get; set; }
        [Display(Name = "Race Won")]
        public int RaceWon { get; set; }
        [Display(Name = "Car with most wins")]
        public string CarWithMostWins { get; set; }
        [Display(Name = "Car with most losses")]
        public string CarWithMostLosses { get; set; }
        [Display(Name = "Track with most wins")]
        public string TrackWithMostWins { get; set; }
        [Display(Name = "Track with most losses")]
        public string TrackWithMostLosses { get; set; }
        [Display(Name = "Category with most wins")]
        public string CategoryWithMostWins { get; set; }
        [Display(Name = "Category with most losses")]
        public string CategoryWithMostLosses { get; set; }
        [Display(Name = "Top Speed Driven")]
        public float TopSpeedDriven { get; set; }
    }
}