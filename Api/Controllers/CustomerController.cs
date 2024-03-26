using Business.Abstracts;
using Entities.Concrets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        { 
           var result =  _customerService.Add(customer);
            if (result.Success) 
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
    }

}
