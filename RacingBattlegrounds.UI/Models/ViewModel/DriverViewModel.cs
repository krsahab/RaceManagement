using System.ComponentModel.DataAnnotations;

namespace RacingBattlegrounds.UI.Models.ViewModel
{
    public class DriverViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}