using Products.API.Models.Enums;

namespace Products.API.Models
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
    }
}
