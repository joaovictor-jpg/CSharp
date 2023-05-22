using Microsoft.EntityFrameworkCore;
using Products.API.Data;
using Products.API.Models;

namespace Products.API.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsContext _productsContext;

        public ProductRepository(ProductsContext productsContext)
        {
            _productsContext = productsContext;
        }

        async Task<List<Product>> IProductRepository.GetProducts()
        {
            return await _productsContext.Products.ToListAsync();
        }
    }
}
