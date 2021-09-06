using API.Context;
using API.Models;
using System.Linq;

namespace API.Repository
{
    public class ProductRepository
    {
        private StarWarsContext context;

        public ProductRepository()
        {
            context = new();
        }

        public Product Create(Product product)
        {
            context.Product.Add(product);

            context.SaveChanges();

            return product;
        }
    }
}
