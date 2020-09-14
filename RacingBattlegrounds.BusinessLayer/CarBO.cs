using AutoMapper;
using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.DataAccess.DAO;
using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;

namespace RacingBattlegrounds.BusinessLayer
{
    public class CarBO
    {
        Mapper mapperOP = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()));
        Mapper mapperIP = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, Car>()));
        public IEnumerable<CarDTO> GetCars()
        {
            return mapperOP.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(CarDetailsDAO.GetCars());
        }
        public CarDTO GetCarDetails(int Id)
        {
            return mapperOP.Map<Car, CarDTO>(CarDetailsDAO.GetCarDetails(Id));
        }
        public void UpdateCarDetails(CarDTO car)
        {
            CarDetailsDAO.UpdateCarDetails(mapperIP.Map<CarDTO, Car>(car));
        }
        public void AddCar(CarDTO car)
        {
            CarDetailsDAO.AddCar(mapperIP.Map<CarDTO, Car>(car));
        }
        public void DeleteCar(int Id)
        {
            CarDetailsDAO.DeleteCar(Id);
        }
    }
}
