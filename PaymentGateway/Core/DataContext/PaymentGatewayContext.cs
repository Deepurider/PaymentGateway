using Microsoft.EntityFrameworkCore;
using PaymentGateway.Core.Models;

namespace PaymentGateway.Core.DataContext
{
    public class PaymentGatewayContext : DbContext
    {
        public DbSet<GoodsAccount> GoodsAccount { get; set; }

        public DbSet<SharesAccount> SharesAccount { get; set; }

        public DbSet<BankAccount> BankAccount { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<BankStatement> bankStatements { get; set; }

        public DbSet<GoodsStatement> goodsStatements { get; set; }

        public DbSet<ShareStatement> shareStatements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PaymentGateway");

        }
    }
}
