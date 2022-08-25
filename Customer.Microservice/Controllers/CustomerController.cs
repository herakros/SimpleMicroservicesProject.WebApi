using CustomerMicroservice.Contracts.DTO;
using CustomerMicroservice.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerMicroservice.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        protected readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService; 
        }

        [HttpPost]
        [Route("customers")]
        public async Task<IActionResult> CreateCustomer(Contracts.Data.Entities.Customer customer)
        {
            await _customerService.CreateCustomerAsync(customer);
            return Ok();
        }

        [HttpGet]
        [Route("customers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customerService.GetAllCustomersAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("customers/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var result = await _customerService.GetCustomerByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("customers/{id}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerDTO customer, int id)
        {
            await _customerService.UpdateCustomerAsync(customer, id);
            return Ok();
        }
    }
}
