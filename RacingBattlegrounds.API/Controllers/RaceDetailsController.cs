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
        RaceDetailsBO raceDetails = new RaceDetailsBO();
        /// <summary>
        /// Get Race Details
        /// </summary>
        /// <remarks>Get All Race Details</remarks>
        /// <returns>List of Races with its details</returns>
        [HttpGet]
        public IEnumerable<RaceDetailsDTO> GetRaceDetails()
        {
            return raceDetails.GetRaceDetails();
        }
    }
}
