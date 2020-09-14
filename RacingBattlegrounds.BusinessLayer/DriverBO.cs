using AutoMapper;
using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.DataAccess.DAO;
using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;

namespace RacingBattlegrounds.BusinessLayer
{
    public class DriverBO
    {
        Mapper mapperOP = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Driver, DriverDTO>()));
        Mapper mapperIP = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<DriverDTO, Driver>()));
        public IEnumerable<DriverDTO> GetDrivers()
        {
            return mapperOP.Map<IEnumerable<Driver>, IEnumerable<DriverDTO>>(DriverDAO.GetDrivers());
        }
        public DriverDTO GetDriverDetails(int Id)
        {
            return mapperOP.Map<Driver, DriverDTO>(DriverDAO.GetDriverDetails(Id));
        }
        public void UpdateDriverDetails(DriverDTO driver)
        {
            DriverDAO.UpdateDriverDetails(mapperIP.Map<DriverDTO, Driver>(driver));
        }
        public void AddDriver(DriverDTO driver)
        {
            DriverDAO.AddDriver(mapperIP.Map<DriverDTO, Driver>(driver));
        }
        public void DeleteDriver(int Id)
        {
            DriverDAO.DeleteDriver(Id);
        }
    }
}
