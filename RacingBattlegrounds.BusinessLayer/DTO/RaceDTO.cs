using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingBattlegrounds.BusinessLayer.DTO
{
    public class RaceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Track_Id { get; set; }
        public int EngineCapacity { get; set; }
    }
}
