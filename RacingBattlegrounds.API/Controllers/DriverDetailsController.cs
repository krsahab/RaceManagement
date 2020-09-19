using RacingBattlegrounds.BusinessLayer;
using RacingBattlegrounds.BusinessLayer.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace RacingBattlegrounds.API.Controllers
{
    /// <summary>
    /// Driver Details Controller
    /// </summary>
    public class DriverDetailsController : ApiController
    {
        DriverDetailsBO driverDetails = new DriverDetailsBO();
        /// <summary>
        /// Get Driver Details
        /// </summary>
        /// <remarks>Get All Drivers Details</remarks>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DriverDetailsDTO> GetDriverDetails()
        {
            return driverDetails.GetDriverDetails();
        }
    }
}
