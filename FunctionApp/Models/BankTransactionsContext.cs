using Microsoft.EntityFrameworkCore;

namespace FunctionApp.Models
{
    public class BankTransactionsContext : DbContext
    {
        public BankTransactionsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankStatement>()
                .HasMany(s => s.BankTransactions)
                .WithOne(t => t.BankStatement)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<BankStatement> BankStatements { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }
    }
}
