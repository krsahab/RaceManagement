using RacingBattlegrounds.BusinessLayer;
using RacingBattlegrounds.BusinessLayer.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace RacingBattlegrounds.API.Controllers
{
    /// <summary>
    /// Car Related Operations
    /// </summary>
    public class CarController : ApiController
    {
        CarBO cars = new CarBO();
        /// <summary>
        /// Get All Cars
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CarDTO> GetCars()
        {
            return cars.GetCars();
        }
        /// <summary>
        /// Get Details Of Particular Car
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CarDTO GetCarDetails(int Id)
        {
            return cars.GetCarDetails(Id);
        }
        /// <summary>
        /// Update Car Details
        /// </summary>
        /// <param name="car"></param>
        [HttpPut]
        public void UpdateCarDetails(CarDTO car)
        {
            cars.UpdateCarDetails(car);
        }
        /// <summary>
        /// Add New Car
        /// </summary>
        /// <param name="car"></param>
        [HttpPost]
        public void AddCar(CarDTO car)
        {
            cars.AddCar(car);
        }
        /// <summary>
        /// Delete an Specific Car
        /// </summary>
        /// <param name="Id"></param>
        [HttpDelete]
        public void DeleteCar(int Id)
        {
            cars.DeleteCar(Id);
        }
    }
}
