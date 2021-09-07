using API.Context;
using API.Models;
using API.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Repository
{
    public class PurchaseRepository
    {
        private readonly StarWarsContext context;
        private readonly IDistributedCache _cache;
        private readonly string _cacheKey;

        public PurchaseRepository(IDistributedCache cache)
        {
            context = new();
            _cacheKey = new DotEnvUtil().EnvVars["CACHE_PURCH_KEY"];
            _cache = cache;
        }

        public async Task<Purchase> CreateFromTransaction(Transaction transaction)
        {
            CultureInfo cult = new CultureInfo("pt-BR");
            string dta = DateTime.Now.ToString("dd/MM/yyyy", cult);

            Purchase purchase = new();

            purchase.ClientId = transaction.ClientId;
            purchase.CardNumber = transaction.CreditCard.CardNumber;
            purchase.TransDate = dta;
            purchase.Amount = transaction.AmountTotal;

            context.Purchase.Add(purchase);

            var affectedRows = await context.SaveChangesAsync();

            if (affectedRows > 0)
            {
                var purchases = await context.Purchase.ToListAsync();
                var json = JsonSerializer.Serialize(purchases);
                await _cache.SetStringAsync(_cacheKey, json);
            }

            return purchase;
        }

        public async Task<List<Purchase>> List(Guid clientId)
        {
            _ = new List<Purchase>();

            var json = await _cache.GetStringAsync(_cacheKey);
            List<Purchase> purchases;
            if (json != null && clientId == Guid.Empty)
            {
                purchases = JsonSerializer.Deserialize<List<Purchase>>(json);
            }
            else
            {
                if (clientId == Guid.Empty)
                {
                    purchases = await context.Purchase.ToListAsync();
                }
                else
                {
                    purchases = await context.Purchase.Where(s => s.ClientId == clientId).ToListAsync();
                }

                json = JsonSerializer.Serialize(purchases);
                await _cache.SetStringAsync(_cacheKey, json);
            }

            return purchases;
        }
    }
}
