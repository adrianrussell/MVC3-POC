using System.Collections.Generic;
using Model;

namespace Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }

    public class ProductService : IProductService
    {
        public List<Product> GetProducts() {
            return new List<Product> { new Product { Name = "Float" }, new Product { Name = "Fixed" }, new Product { Name = "Cap" }, new Product {Name = "Range"}};
        }
    }
}