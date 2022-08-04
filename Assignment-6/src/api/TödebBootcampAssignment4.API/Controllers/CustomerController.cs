using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TödebBootcampAssignment4.BusinessLayer.Features.Abstract;
using TödebBootcampAssignment4.DTOs.Customer;

namespace TödebBootcampAssignment4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CreateCustomerDto createCustomerDto)
        {
            var value = await _customerService.AddAsync(createCustomerDto);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerDto updateCustomerDto)
        {
            var value = await _customerService.Update(updateCustomerDto);
            return Ok(value);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var value = _customerService.GetAll();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByİd(string id)
        {
            var value = await _customerService.GetAsync(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            await _customerService.Remove(await _customerService.GetAsync(id));
            return Ok();
        }


    }
}
