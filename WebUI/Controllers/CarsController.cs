using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarManager _carManager;
        public CarsController(ICarManager carManager)
        {
            _carManager = carManager;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            var model = new CarListViewModel
            {
                Cars = (List<Car>)_carManager.GetAll()
            };
            return View(model);
        }
    }
}

