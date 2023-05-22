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

        public async Task<Product> Save(Product product)
        {
            await _productsContext.Products.AddAsync(product);

            await _productsContext.SaveChangesAsync();

            return product;
        }

        async Task<List<Product>> IProductRepository.GetProducts()
        {
            return await _productsContext.Products.ToListAsync();
        }
    }
}
