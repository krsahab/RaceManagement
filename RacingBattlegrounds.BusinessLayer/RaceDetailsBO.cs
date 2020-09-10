using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacingBattlegrounds.DataAccess.DAO;
using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.BusinessLayer.Utility;

namespace RacingBattlegrounds.BusinessLayer
{
    public class RaceDetailsBO
    {
        public IEnumerable<RaceDetailsDTO> GetRaceDetails()
        {
            return RaceDetailsDAO.GetRaceDetails().ConvertAll(x=>x.ConvertToRaceDetailsDTO());
        }
    }
}
