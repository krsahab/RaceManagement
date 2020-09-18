using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public static class DriverDAO
    {
        private static readonly ApplicationDBContext context;
        static DriverDAO()
        {
            context = new ApplicationDBContext();
        }
        public static List<Driver> GetDrivers()
        {
            return context.Drivers.ToList();
        }
        public static Driver GetDriverDetails(int Id)
        {
            return context.Drivers.Find(Id);
        }
        public static void UpdateDriverDetails(Driver driver)
        {
            context.Entry(driver).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public static void AddDriver(Driver driver)
        {
            context.Drivers.Add(driver);
            context.SaveChanges();
        }
        public static void DeleteDriver(int Id)
        {
            Driver driver = context.Drivers.Find(Id);
            context.Drivers.Remove(driver);
            context.SaveChanges();
        }
    }
}
