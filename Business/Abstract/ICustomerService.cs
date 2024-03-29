﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int customerId);
        IResult Update(Customer customer);
    }
}
