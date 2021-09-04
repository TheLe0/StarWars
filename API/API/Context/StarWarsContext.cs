using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace API.Context
{
    public class StarWarsContext : DefaultDbContext
    {
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Models.Transaction> Transaction { get; set; }

        public static TransactionScope RepeatableReadScope()
        {
            TransactionOptions transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead
            };

            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
    }
}
