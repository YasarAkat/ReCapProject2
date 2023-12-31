﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckForCarImageLimit(carImage.CarId)); // 5 ten fazla araba resmi eklenemez.
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelperService.Upload(file, PathConstants.CarImagesPath); //dosya ve dosya yolu
            carImage.Date = DateTime.Now; // şu anki zaman

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);

        }

     
        public IResult Delete(CarImage carImage)
        {
            _fileHelperService.Delete(PathConstants.CarImagesPath + carImage.ImagePath); //resim yolu ve dosya yolu

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<CarImage> GetById(int ImageId)
        {
            
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarImageId == ImageId), Messages.ImagesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int CarId)
        {
            IResult result = BusinessRules.Run(CheckImageExists(CarId));//Dosya var mı yok mu onun kontrolü
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(CarId).Data); //resim eklenmediği zaman default eklenecek resim
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == CarId), Messages.ImagesListedByCarId);
        }

        [ValidationAspect(typeof(CarImageValidator))]
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
            if(result >= 5)
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
