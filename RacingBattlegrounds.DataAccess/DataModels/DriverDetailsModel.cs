using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingBattlegrounds.DataAccess.DataModels
{
    public class DriverDetailsModel
    {
        public int DriverId { get; set; }
        public string CarWithMostWin { get; set; }
        public int? CategoryWithMostWin { get; set; }
        public string TrackWithMostWin { get; set; }
        public string CarWithMostLose { get; set; }
        public int? CategoryWithMostLose { get; set; }
        public string TrackWithMostLose { get; set; }
    }
}
