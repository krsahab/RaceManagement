using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.BusinessLayer.Utility;
using RacingBattlegrounds.DataAccess.DAO;
using System.Collections.Generic;

namespace RacingBattlegrounds.BusinessLayer
{
    public class RaceDetailsBO
    {
        public IEnumerable<RaceDetailsDTO> GetRaceDetails()
        {
            return RaceDetailsDAO.GetRaceDetails().ConvertAll(x => x.ConvertToRaceDetailsDTO());
        }
    }
}
