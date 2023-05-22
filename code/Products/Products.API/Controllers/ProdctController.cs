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
            return Ok(await _productRepository.Save(product));
        }
    }
}
