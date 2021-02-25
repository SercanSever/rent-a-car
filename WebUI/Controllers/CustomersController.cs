using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Abstract;

namespace WebUI.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerManager _customerManager;
        public CustomersController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        [HttpGet]
        public ActionResult List()
        {
            var result = _customerManager.GetAll();
            return View(result);
        }
    }
}