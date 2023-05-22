using Products.API.Models;

namespace Products.API.Repository.Products
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();

        Task<Product> Save(Product product);
    }
}
