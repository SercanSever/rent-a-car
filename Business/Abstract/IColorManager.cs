using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorManager
    {
        IResult Add(Color color);
        IResult Delete(int colorId);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int colorId);
        IResult Update(Color color);
    }
}
