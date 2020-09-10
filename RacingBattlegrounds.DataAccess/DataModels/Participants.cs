using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacingBattlegrounds.DataAccess.DataModels
{
    public class Participants
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Driver Driver { get; set; }
        [Required]
        public Race Race { get; set; }
        [Required]
        public Car Car { get; set; }
        [Required]
        public float TopSpeed { get; set; }
        [Required]
        public int CompletionTime { get; set; }
        [Required]
        public bool IsWinner { get; set; }
    }
}
