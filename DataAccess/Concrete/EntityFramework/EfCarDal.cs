using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public IDataResult<List<CarDetailDto>> GetCarNameBrandNameColorNameDailyPrice()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var detailResult = from c in context.Cars
                                   join b in context.Brands
                                   on c.BrandId equals b.BrandId
                                   join cl in context.Colors
                                   on c.ColorId equals cl.ColorId
                                   select new CarDetailDto
                                   {
                                       CarId = c.CarId,
                                       BrandName = b.BrandName,
                                       ColorName = cl.ColorName,
                                       DailyPrice = c.DailyPrice
                                   };
                return new SuccessDataResult<List<CarDetailDto>>(detailResult.ToList());
            }
        }
    }
}
