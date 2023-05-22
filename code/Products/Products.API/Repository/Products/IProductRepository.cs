using Products.API.Models;

namespace Products.API.Repository.Products
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();

        Task<Product> GetProductById(int id);

        Task<Product> Save(Product product);

        Task<Product> Update(Product product);

        Task<Product> Delete(Product product);
    }
}
