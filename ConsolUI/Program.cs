using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());

            DTOTest(carManager);


            //Console.WriteLine(carManager.GetById(10).CarName);
            //DeleteTest(carManager);
            //UpdateTest(carManager);
            //AddTest(carManager);

        }

        private static void DTOTest(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} / {1} / {2} / {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
            }
            
        }

        private static void AddTest(CarManager carManager)
        {
            carManager.Add(new Car { CarId = 3, BrandId = 3, ColorId = 2, CarName = "320D", DailyPrice = 1500, ModelYear = "2021", Description = "Konforlu araba" });
            carManager.Add(new Car { CarId = 4, BrandId = 2, ColorId = 4, CarName = "A5 Coupe", DailyPrice = 1000, ModelYear = "2020", Description = "Uygun araba" });
            carManager.Add(new Car { CarId = 10, BrandId = 3, ColorId = 2, CarName = "Daıhatsu", DailyPrice = 800, ModelYear = "2018", Description = "Ekonomik Araba" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Model: {car.CarName} Marka: {car.BrandId} Renk: {car.ColorId} Günlük Fiyat: {car.DailyPrice} Açıklama: {car.Description}");
            }
        }

        private static void UpdateTest(CarManager carManager)
        {
            carManager.Update(new Car { CarId = 4, BrandId = 2, ColorId = 4, CarName = "A5 Sedan", DailyPrice = 1500, ModelYear = "2020", Description = "Uygun araba" });
        }

        private static void DeleteTest(CarManager carManager)
        {
            carManager.Delete(new Car { CarId = 7, BrandId = 3, ColorId = 2, CarName = "Daıhatsu", DailyPrice = 800, ModelYear = "2018", Description = "Ekonomik Araba" });
            carManager.Delete(new Car { CarId = 2, BrandId = 4, ColorId = 3, CarName = "Astra", DailyPrice = 2000, ModelYear = "2020", Description = "pahalı araba" });
            carManager.Delete(new Car { CarId = 5, BrandId = 1, ColorId = 1, CarName = "S500", DailyPrice = 1500, ModelYear = "2021", Description = "Performanslı araba" });
        }

    }
}
