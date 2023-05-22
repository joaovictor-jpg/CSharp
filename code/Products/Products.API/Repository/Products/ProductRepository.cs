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

        public async Task<Product> Delete(Product product)
        {
            _productsContext.Remove(product);
            await _productsContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productsContext.Products.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Product> Save(Product product)
        {
            await _productsContext.Products.AddAsync(product);

            await _productsContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _productsContext.Products.Update(product);
            await _productsContext.SaveChangesAsync();

            return product;
        }

        async Task<List<Product>> IProductRepository.GetProducts()
        {
            return await _productsContext.Products.ToListAsync();
        }
    }
}
