using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageManager _carImageManager;

        public CarImagesController(ICarImageManager carImageManager)
        {
            _carImageManager = carImageManager;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _carImageManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _carImageManager.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getFileById")]
        public IActionResult GetFileById(int id)
        {
            var result = _carImageManager.GetById(id);
            if (result.Success)
            {
                var data = System.IO.File.ReadAllBytes(result.Data.ImagePath);
                return File(data, "image/jpeg");
            }
            return BadRequest(result);
        }
        [HttpGet("getImagesByCarId")]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _carImageManager.GetImagesByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, [FromForm(Name = "Image")] IFormFile file)
        {
            var result = _carImageManager.Add(carImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage,[FromForm(Name ="Image")]IFormFile file)
        {
            var result = _carImageManager.Update(carImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageManager.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
