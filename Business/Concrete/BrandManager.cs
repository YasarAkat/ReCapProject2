using Business.Abstract;
using Business.Constants;
using Core.Utilites.Result;
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
        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }
            else 
            {
                _branDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
        }

        public IResult Delete(Brand brand)
        {
            _branDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new DataResult<List<Brand>>(_branDal.GetAll(),true);
           
        }

        public IDataResult<Brand> GetById(int BrandId)
        {
            return new DataResult<Brand>(_branDal.Get(b => b.BrandId == BrandId),true);
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }
            else
            {
                _branDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
        }
    }
}
