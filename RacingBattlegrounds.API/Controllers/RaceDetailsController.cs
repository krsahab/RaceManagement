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
