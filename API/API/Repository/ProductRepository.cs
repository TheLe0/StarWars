using API.Context;
using API.Models;
using API.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

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

        public async Task<Product> Create(Product product)
        {
            context.Product.Add(product);

            var affectedRows = await context.SaveChangesAsync();

            if (affectedRows > 0)
            {
                var products = await context.Product.ToListAsync();
                var json = JsonSerializer.Serialize(products);
                await _cache.SetStringAsync(_cacheKey, json);
            }

            return product;
        }

        public async Task<List<Product>> ListAll()
        {
            _ = new List<Product>();

            var json = await _cache.GetStringAsync(_cacheKey);
            List<Product> products;
            if (json != null)
            {
                products = JsonSerializer.Deserialize<List<Product>>(json);
            }
            else
            {
                products = await context.Product.ToListAsync();

                json = JsonSerializer.Serialize(products);
                await _cache.SetStringAsync(_cacheKey, json);
            }

            return products;
        }
    }
}
