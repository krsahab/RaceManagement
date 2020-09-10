using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RacingBattlegrounds.UI.Models.ViewModel
{
    public class RaceViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Track_Id { get; set; }
        public SelectList Tracks { get; set; }
        [Required]
        public int EngineCapacity { get; set; }
    }
}