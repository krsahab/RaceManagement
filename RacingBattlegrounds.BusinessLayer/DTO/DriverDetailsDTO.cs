using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingBattlegrounds.BusinessLayer.DTO
{
    public class DriverDetailsDTO
    {
        public string DriverName { get; set; }
        public int RaceParticipated { get; set; }
        public int RaceWon { get; set; }
        public string CarWithMostWins { get; set; }
        public string CarWithMostLosses { get; set; }
        public string TrackWithMostWins { get; set; }
        public string TrackWithMostLosses { get; set; }
        public string CategoryWithMostWins { get; set; }
        public string CategoryWithMostLosses { get; set; }
        public float TopSpeedDriven { get; set; }
    }
}
