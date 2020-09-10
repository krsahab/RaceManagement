using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RacingBattlegrounds.UI.Models.ViewModel
{
    public class CarViewModel
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public int EngineCapacity { get; set; }
    }
}