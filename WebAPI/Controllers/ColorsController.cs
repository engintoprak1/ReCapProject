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
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);

            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);

            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _colorService.Delete(id);

            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();

            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);

            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
