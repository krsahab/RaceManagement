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
