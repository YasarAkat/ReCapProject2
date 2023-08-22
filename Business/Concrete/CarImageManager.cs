using Business.Abstract;
using Business.Constants;
using Core.Utilites.Business;
using Core.Utilites.Helpers.FileHelper;
using Core.Utilites.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelperService _fileHelperService;

        public CarImageManager(ICarImageDal carImageDal, IFileHelperService fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;
        }

        
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckForCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelperService.Upload(file, PathConstants.CarImagesPath);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);

        }

     
        public IResult Delete(CarImage carImage)
        {
            _fileHelperService.Delete(PathConstants.CarImagesPath + carImage.ImagePath);

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(Messages.ImagesListed);
        }

        public IDataResult<CarImage> GetByImageId(int ImageId)
        {
            _carImageDal.Get(i => i.CarImageId == ImageId);
            return new SuccessDataResult<CarImage>();
        }

        public IDataResult<List<CarImage>> GetByCarId(int CarId)
        {
            IResult result = BusinessRules.Run(CheckImageExists(CarId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(CarId).Data);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == CarId), Messages.ImagesListedByCarId);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            
            carImage.ImagePath = _fileHelperService.Update(file, PathConstants.CarImagesPath + carImage.ImagePath,PathConstants.CarImagesPath);
            
            carImage.Date = DateTime.Now;
            
            _carImageDal.Update(carImage);
           
            return new SuccessResult(Messages.ImageUpdated);
        }

        private IResult CheckForCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if(result > 5)
            {
                return new ErrorResult(Messages.CarImageLimitReached);
            }
            return new SuccessResult();
        }

        private IResult CheckImageExists(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;

            if (result > 0)
            {
                return new ErrorResult(Messages.CarImageAlreadyHave);
            }
            return new SuccessResult();

        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "Logo.jpg" });

            return new SuccessDataResult<List<CarImage>>(carImages);
        }
    }
}
