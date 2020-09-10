using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacingBattlegrounds.DataAccess.DataModels;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public static class CarDetailsDAO
    {
        public static List<Car> GetCars()
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Cars.ToList();
            }
        }
        public static Car GetCarDetails(int Id)
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Cars.Find(Id);
            }
        }
        public static void UpdateCarDetails(Car car)
        {
            using (var context = new ApplicationDBContext())
            {
                context.Entry(car).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void AddCar(Car car)
        {
            using (var context = new ApplicationDBContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }
        public static void DeleteCar(int Id)
        {
            using (var context = new ApplicationDBContext())
            {
                Car car = context.Cars.Find(Id);
                context.Cars.Remove(car);
                context.SaveChanges();
            }
        }
    }
}
