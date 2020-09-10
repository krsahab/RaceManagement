using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using RacingBattlegrounds.DataAccess.DataModels;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public class DriverDAO
    {
        public static List<Driver> GetDrivers()
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Drivers.ToList();
            }
        }
        public static Driver GetDriverDetails(int Id)
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Drivers.Find(Id);
            }
        }
        public static void UpdateDriverDetails(Driver driver)
        {
            using (var context = new ApplicationDBContext())
            {
                context.Entry(driver).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void AddDriver(Driver driver)
        {
            using (var context = new ApplicationDBContext())
            {
                context.Drivers.Add(driver);
                context.SaveChanges();
            }
        }
        public static void DeleteDriver(int Id)
        {
            using (var context = new ApplicationDBContext())
            {
                Driver driver = context.Drivers.Find(Id);
                context.Drivers.Remove(driver);
                context.SaveChanges();
            }
        }
    }
}
