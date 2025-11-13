using BeauProject.Accounting.Data.EntityValidator;
using BeauProject.Accounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeauProject.Accounting.Data.Context
{
    public class AccountingContext : DbContext
    {
        public AccountingContext(DbContextOptions<AccountingContext> options)
            : base(options) { }

        public DbSet<AccountGroup> AccountGroups { get; set; } = null!;
        public DbSet<AccountGroupTranslation> AccountGroupTranslations { get; set; } = null!;
        public DbSet<AccountSubGroup> AccountSubGroups { get; set; } = null!;
        public DbSet<AccountSubGroupTranslation> AccountSubGroupTranslations { get; set; } = null!;
        public DbSet<AccountDetail> AccountDetails { get; set; } = null!;
        public DbSet<AccountDetailTranslation> AccountDetailTranslations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Fluent API Configurations
            modelBuilder.ApplyConfiguration(new AccountGroupValidator());
            modelBuilder.ApplyConfiguration(new AccountGroupTranslationValidator());
            modelBuilder.ApplyConfiguration(new AccountSubGroupValidator());
            modelBuilder.ApplyConfiguration(new AccountSubGroupTranslationValidator());
            modelBuilder.ApplyConfiguration(new AccountDetailValidator());
            modelBuilder.ApplyConfiguration(new AccountDetailTranslationValidator());

            base.OnModelCreating(modelBuilder);
        }
    }
}
