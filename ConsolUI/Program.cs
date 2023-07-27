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

            Console.WriteLine(carManager.GetById(10).CarName);

            //carManager.Delete(new Car { CarId = 7, BrandId = 3, ColorId = 2, CarName = "Daıhatsu", DailyPrice = 800, ModelYear = "2018", Description = "Ekonomik Araba" });
            //carManager.Delete(new Car { CarId = 2, BrandId = 4, ColorId = 3, CarName = "Astra", DailyPrice = 2000, ModelYear = "2020", Description = "pahalı araba" });
            //carManager.Update(new Car { CarId = 4, BrandId = 2, ColorId = 4, CarName = "A5 Sedan", DailyPrice = 1500, ModelYear = "2020", Description = "Uygun araba" });
            //carManager.Delete(new Car { CarId = 5, BrandId = 1, ColorId = 1, CarName = "S500", DailyPrice = 1500, ModelYear = "2021", Description = "Performanslı araba" });
            //carManager.Add(new Car { CarId = 3, BrandId = 3, ColorId = 2, CarName = "320D", DailyPrice = 1500, ModelYear = "2021", Description = "Konforlu araba" });
            //carManager.Add(new Car { CarId = 4, BrandId = 2, ColorId = 4, CarName = "A5 Coupe", DailyPrice = 1000, ModelYear = "2020", Description = "Uygun araba" });
            //carManager.Add(new Car {CarId = 10, BrandId = 3, ColorId = 2, CarName = "Daıhatsu", DailyPrice = 800, ModelYear = "2018", Description = "Ekonomik Araba" });
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine($"Model: {car.CarName} Marka: {car.BrandId} Renk: {car.ColorId} Günlük Fiyat: {car.DailyPrice} Açıklama: {car.Description}");
            //}

        }

       
    }
}
