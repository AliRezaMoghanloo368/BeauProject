using BeauProject.Restaurant.Domain.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Restaurant.Data.EntityValidator.AccountsValidator
{
    public class AccountDetailValidator : IEntityTypeConfiguration<AccountDetail>
    {
        public void Configure(EntityTypeBuilder<AccountDetail> builder)
        {
            builder.ToTable("AccountDetails");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Code)
                  .HasMaxLength(50)
                  .IsRequired();

            builder.Property(e => e.IsActive)
                  .HasDefaultValue(true);

            // رابطه با Translations (با cascade delete)
            builder.HasMany(d => d.Translations)
                  .WithOne(t => t.AccountDetail)
                  .HasForeignKey(t => t.AccountDetailId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
