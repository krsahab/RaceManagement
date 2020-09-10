using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.BusinessLayer;

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
        /// <param name="car"></param>
        [HttpPut]
        public void UpdateRaceDetails(RaceDTO car)
        {
            race.UpdateRaceDetails(car);
        }
        /// <summary>
        /// Add New Race
        /// </summary>
        /// <param name="car"></param>
        [HttpPost]
        public void AddRace(RaceDTO car)
        {
            race.AddRace(car);
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
