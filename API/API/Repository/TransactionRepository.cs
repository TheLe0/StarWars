using API.Context;
using API.Models;
using API.Utils;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Repository
{
    public class TransactionRepository
    {
        private readonly StarWarsContext context;
        private readonly PurchaseRepository purchase;

        public TransactionRepository(IDistributedCache cache)
        {
            context = new();
            purchase = new(cache);
        }

        public async Task<Transaction> Create(Transaction transaction)
        {
            context.Transaction.Add(transaction);

            await context.SaveChangesAsync();

            await purchase.CreateFromTransaction(transaction);

            return transaction;
        }
    }
}
