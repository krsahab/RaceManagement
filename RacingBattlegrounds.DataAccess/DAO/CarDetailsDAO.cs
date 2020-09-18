using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public static class CarDetailsDAO
    {
        private static readonly ApplicationDBContext context;
        static CarDetailsDAO()
        {
            context = new ApplicationDBContext();
        }
        public static List<Car> GetCars()
        {
            return context.Cars.ToList();
        }
        public static Car GetCarDetails(int Id)
        {
            return context.Cars.Find(Id);
        }
        public static void UpdateCarDetails(Car car)
        {
            context.Entry(car).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public static void AddCar(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
        }
        public static void DeleteCar(int Id)
        {
            Car car = context.Cars.Find(Id);
            context.Cars.Remove(car);
            context.SaveChanges();
        }
    }
}
