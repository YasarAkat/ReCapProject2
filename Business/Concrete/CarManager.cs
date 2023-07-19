using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                Console.WriteLine("The Car Name must have minimum 2 character.");
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Daily Price must be greater than zero.");
            }
            else
            {
                _carDal.Add(car);
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            return _carDal.GetAll(p => p.BrandId == BrandId);
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            return _carDal.GetAll(p => p.ColorId == ColorId);
        }

        public void Update(Car car)
        {
            if (car.CarName.Length < 2)
            {
                Console.WriteLine("The Car Name must have minimum 2 character.");
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Daily Price must be greater than zero.");
            }
            else
            {
                _carDal.Add(car);
            }
        }
    }
}
