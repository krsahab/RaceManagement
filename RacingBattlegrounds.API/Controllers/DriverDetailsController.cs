using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RacingBattlegrounds.BusinessLayer;
using RacingBattlegrounds.BusinessLayer.DTO;

namespace RacingBattlegrounds.API.Controllers
{
    /// <summary>
    /// Driver Details Controller
    /// </summary>
    public class DriverDetailsController : ApiController
    {
        /// <summary>
        /// Get Driver Details
        /// </summary>
        /// <remarks>Get All Drivers Details</remarks>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DriverDetailsDTO> GetDriverDetails()
        {
            DriverDetailsBO driverDetails = new DriverDetailsBO();
            return driverDetails.GetDriverDetails();
        }
    }
}
