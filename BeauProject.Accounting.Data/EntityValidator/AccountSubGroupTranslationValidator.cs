using BeauProject.Accounting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Accounting.Data.EntityValidator
{
    public class AccountSubGroupTranslationValidator : IEntityTypeConfiguration<AccountSubGroupTranslation>
    {
        public void Configure(EntityTypeBuilder<AccountSubGroupTranslation> builder)
        {
            builder.ToTable("AccountSubGroupTranslations");

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
