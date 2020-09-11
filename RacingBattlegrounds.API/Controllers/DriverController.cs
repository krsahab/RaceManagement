using RacingBattlegrounds.BusinessLayer;
using RacingBattlegrounds.BusinessLayer.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace RacingBattlegrounds.API.Controllers
{
    public class DriverController : ApiController
    {
        DriverBO driverObject = new DriverBO();
        /// <summary>
        /// Get All Drivers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DriverDTO> GetDrivers()
        {
            return driverObject.GetDrivers();
        }
        /// <summary>
        /// Get Details Of Particular Driver
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DriverDTO GetDriverDetails(int Id)
        {
            return driverObject.GetDriverDetails(Id);
        }
        /// <summary>
        /// Update Driver Details
        /// </summary>
        /// <param name="driver"></param>
        [HttpPut]
        public void UpdateDriverDetails(DriverDTO driver)
        {
            driverObject.UpdateDriverDetails(driver);
        }
        /// <summary>
        /// Add New Driver
        /// </summary>
        /// <param name="driver"></param>
        [HttpPost]
        public void AddDriver(DriverDTO driver)
        {
            driverObject.AddDriver(driver);
        }
        /// <summary>
        /// Delete an Specific Driver
        /// </summary>
        /// <param name="Id"></param>
        [HttpDelete]
        public void DeleteDriver(int Id)
        {
            driverObject.DeleteDriver(Id);
        }
    }
}
