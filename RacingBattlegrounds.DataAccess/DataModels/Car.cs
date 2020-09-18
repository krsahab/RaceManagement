﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacingBattlegrounds.DataAccess.DataModels
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        public int EngineCapacity { get; set; }
    }
}
