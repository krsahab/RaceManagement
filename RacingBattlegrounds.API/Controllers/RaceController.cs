using RacingBattlegrounds.BusinessLayer;
using RacingBattlegrounds.BusinessLayer.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace RacingBattlegrounds.API.Controllers
{
    /// <summary>
    /// Race Details
    /// </summary>
    public class RaceController : ApiController
    {
        RaceBO race = new RaceBO();
        /// <summary>
        /// Get All Races
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RaceDTO> GetRaces()
        {
            return race.GetRaces();
        }
        /// <summary>
        /// Get Details Of Particular Race
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public RaceDTO GetRaceDetails(int Id)
        {
            return race.GetRaceDetails(Id);
        }
        /// <summary>
        /// Update Race Details
        /// </summary>
        /// <param name="Race"></param>
        [HttpPut]
        public void UpdateRaceDetails(RaceDTO Race)
        {
            race.UpdateRaceDetails(Race);
        }
        /// <summary>
        /// Add New Race
        /// </summary>
        /// <param name="Race"></param>
        [HttpPost]
        public void AddRace(RaceDTO Race)
        {
            race.AddRace(Race);
        }
        /// <summary>
        /// Delete an Specific Race
        /// </summary>
        /// <param name="Id"></param>
        [HttpDelete]
        public void DeleteRace(int Id)
        {
            race.DeleteRace(Id);
        }
    }
}
