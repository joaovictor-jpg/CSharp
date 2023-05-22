using Microsoft.AspNetCore.Mvc;
using Products.API.Models;
using Products.API.Repository.Products;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdctController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProdctController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("/products")]
        public async Task<ActionResult> GetProduct()
        {
            return Ok(await _productRepository.GetProducts());
        }

        [HttpPost]
        [Route("/products")]
        public async Task<ActionResult> Save(Product product)
        {
            return Created($"Product/products/{product.id}",new
            {
                data = await _productRepository.Save(product),
                success = true,
                message = "Create product with success"
            });
        }

        [HttpPut]
        [Route("/products")]
        public async Task<ActionResult> Update(Product product)
        {
            Product productDb = await _productRepository.GetProductById(product.id);

            if (productDb == null) return NotFound("product not found");

            productDb.Name = product.Name;
            productDb.Price = product.Price;
            productDb.Category = product.Category;

            return Ok(new
            {
                data = await _productRepository.Update(productDb),
                success = true,
                message = "Product updated"
            });

        }

        [HttpDelete]
        [Route("/products")]
        public async Task<ActionResult> Delete(int id)
        {
            Product productDb = await _productRepository.GetProductById(id);

            if (productDb == null) return NotFound("product not found");

            await _productRepository.Delete(productDb);
            return NoContent();
        }

    }
}
