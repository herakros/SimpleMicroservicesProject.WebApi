using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Data;
using ProductMicroservice.Models;
using ProductMicroservice.Models.DTOs;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly IRepository _productRepository;
        public ProductController(IRepository repository)
        {
            _productRepository = repository;
        }

        [HttpPost]
        [Route("products")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("customers")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("customers/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _productRepository.GetByKeyAsync(id));
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var product = await _productRepository.GetByKeyAsync(id);

            if(product != null)
            {
                await _productRepository.DeleteAsync(product);
                await _productRepository.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPut]
        [Route("customers/{id}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateProductDTO model, int id)
        {
            var product = await _productRepository.GetByKeyAsync(id);

            if(product != null)
            {
                product.Price = model.Price;
                product.Name = model.Name;

                await _productRepository.UpdateAsync(product);
                await _productRepository.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
