using Business.Abstract;
using Business.Constants;
using Core.Files;
using Core.Utilities.BusinessEngine;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageManager
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            BusinessRules.Run(ChechImageCount(carImage.CarId));

            carImage.ImagePath = new FileSystem().Add(file, CreateNewPath(file));
            carImage.UploadDate = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult();
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var carImageToUpdate = _carImageDal.Get(x => x.CarImageId == carImage.CarImageId);
            carImage.CarId = carImageToUpdate.CarId;
            carImage.ImagePath = new FileSystem().Update(carImageToUpdate.ImagePath, file, CreateNewPath(file));
            carImage.UploadDate = DateTime.Now;
            _carImageDal.Update(carImage);

            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            new FileSystem().Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);

            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            var result = _carImageDal.Get(x => x.CarImageId == carImageId);
            CheckImageExists(ref result);
            return new SuccessDataResult<CarImage>(result);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId);
            CheckImageExists(ref result);
            return new SuccessDataResult<List<CarImage>>(result);
        }

        private string CreateNewPath(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);
            var newPath = $@"{Environment.CurrentDirectory}\Upload\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Date}_{DateTime.Now.Year}{fileInfo.Extension}";
            return newPath;
        }
        private IResult ChechImageCount(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId).Count;
            if (result >= 5) return new ErrorResult();

            return new SuccessResult();
        }
        private void CheckImageExists(ref List<CarImage> carImage)
        {
            if (!carImage.Any())
            {
                carImage.Add(CreateDefaultImage());
            }
        }
        private void CheckImageExists(ref CarImage carImage)
        {
            if (carImage == null)
            {
                carImage = CreateDefaultImage();
            }
        }
        public CarImage CreateDefaultImage()
        {
            var defaultImage = new CarImage
            {
                ImagePath = $@"{Environment.CurrentDirectory}\Upload\default.png",
                UploadDate = DateTime.Now
            };
            return defaultImage;
        }
    }
}


