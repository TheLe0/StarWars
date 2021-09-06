using API.Context;
using API.Models;
using API.Utils;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace API.Repository
{
    public class ProductRepository
    {
        private readonly StarWarsContext context;
        private readonly IDistributedCache _cache;
        private readonly string _cacheKey;

        public ProductRepository(IDistributedCache cache)
        {
            context = new();
            _cacheKey = new DotEnvUtil().EnvVars["CACHE_PROD_KEY"];
            _cache = cache;
        }

        public Product Create(Product product)
        {
            context.Product.Add(product);

            var affectedRows = context.SaveChanges();

            if (affectedRows > 0)
            {
                var products = context.Product.ToList();
                var json = JsonSerializer.Serialize(products);
                _cache.SetString(_cacheKey, json);
            }

            return product;
        }

        public List<Product> ListAll()
        {
            var products = new List<Product>();

            var json = _cache.GetString(_cacheKey);

            if (json != null)
            {
                products = JsonSerializer.Deserialize<List<Product>>(json);
            }
            else
            {
                products = context.Product.ToList();

                json = JsonSerializer.Serialize(products);
                _cache.SetString(_cacheKey, json);
            }

            return products;
        }
    }
}
