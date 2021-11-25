using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("add")]
        public IActionResult Add(CarForAddDto car)
        {
            var result = _carService.Add(car);
            return StatusCode(result.Success ? 200 : 400, result);
            
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _carService.Delete(id);
            return StatusCode(result.Success ? 200 : 400, result);
            
        }

        [HttpPut("update")]
        public IActionResult Update(CarForUpdateDto car)
        {
            var result = _carService.Update(car);
            return StatusCode(result.Success ? 200 : 400, result);
            
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
            
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
            
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("getcardetailbyid")]
        public IActionResult GetCarDetailById(int id)
        {
            var result = _carService.GetCarDetailById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            return StatusCode(result.Success ? 200 : 400, result);

        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            return StatusCode(result.Success ? 200 : 400, result);

        }

        [HttpGet("getcardetailsbybrandandcolorid")]
        public IActionResult GetCarDetailsByBrandAndColorId(int brandId,int colorId)
        {
            var result = _carService.GetCarDetailsByBrandAndColorId(brandId,colorId);
            return StatusCode(result.Success ? 200 : 400, result);

        }


    }
}
