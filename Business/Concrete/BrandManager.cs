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
    public class BrandManager : IBrandService
    {
        IBrandDal _branDal;

        public BrandManager(IBrandDal brandDal)
        {
            _branDal = brandDal;
        }
        public void Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                Console.WriteLine("The Car Name must have minimum 2 character.");
            }
            else 
            {
                _branDal.Add(brand);
            }
        }

        public void Delete(Brand brand)
        {
            _branDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _branDal.GetAll();
        }

        public Brand GetById(int BrandId)
        {
            return _branDal.Get(b => b.BrandId == BrandId);
        }

        public void Update(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                Console.WriteLine("The Car Name must have minimum 2 character.");
            }
            else
            {
                _branDal.Add(brand);
            }
        }
    }
}
