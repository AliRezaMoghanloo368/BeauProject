using BeauProject.Restaurant.Domain.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Restaurant.Data.EntityValidator.AccountsValidator
{
    public class AccountGroupTranslationValidator : IEntityTypeConfiguration<AccountGroupTranslation>
    {
        public void Configure(EntityTypeBuilder<AccountGroupTranslation> builder)
        {
            builder.ToTable("AccountGroupTranslations");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Language)
                  .HasMaxLength(5)
                  .IsRequired();

            builder.Property(e => e.Name)
                  .HasMaxLength(200)
                  .IsRequired();

            builder.Property(e => e.Description)
                  .HasMaxLength(500);
        }
    }
}
