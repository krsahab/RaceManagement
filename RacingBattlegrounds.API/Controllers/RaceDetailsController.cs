using RacingBattlegrounds.BusinessLayer;
using RacingBattlegrounds.BusinessLayer.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace RacingBattlegrounds.API.Controllers
{
    /// <summary>
    /// Race Details Controller
    /// </summary>
    public class RaceDetailsController : ApiController
    {
        /// <summary>
        /// Get Race Details
        /// </summary>
        /// <remarks>Get All Race Details</remarks>
        /// <returns>List of Races with its details</returns>
        [HttpGet]
        public IEnumerable<RaceDetailsDTO> GetRaceDetails()
        {
            RaceDetailsBO raceDetails = new RaceDetailsBO();
            return raceDetails.GetRaceDetails();
        }
    }
}
