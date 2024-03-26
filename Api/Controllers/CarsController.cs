using Business.Abstracts;
using Entities.Concrets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() {

            var dataResult = _carService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult.Data);
            }
            return BadRequest(dataResult.Message);
           
        }

        
        [HttpGet("get")]
        public IActionResult Get(int id)
        {

            var dataResult = _carService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult.Data);
            }
            return BadRequest(dataResult.Message);

        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {

            var dataResult = _carService.Add(car);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult.Message);

        }





    }
}
