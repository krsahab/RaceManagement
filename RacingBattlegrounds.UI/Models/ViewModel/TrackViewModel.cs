using System.ComponentModel.DataAnnotations;

namespace RacingBattlegrounds.UI.Models.ViewModel
{
    public class TrackViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int Length { get; set; }
    }
}