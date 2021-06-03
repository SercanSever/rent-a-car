using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessEngine;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalManager
    {
        private IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            BusinessRules.Run(IsCarReturn(rental));

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Delete);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.List);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Update);
        }

        public IResult CheckReturnDateByCarId(int id)
        {
            var result = _rentalDal.GetAll(x => x.CarId == id && x.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult("Undelivered Car");
            }
            return new SuccessResult();
        }

        public IResult IsRentable(Rental rental)
        {
            if (rental.RentDate != null && rental.ReturnDate == null)
            {
                return new ErrorDataResult<Rental>(rental, Messages.NotValid);
            }
            else
            {
                return new SuccessResult();
            }
        }
    }
}
