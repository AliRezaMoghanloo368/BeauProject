using BeauProject.Restaurant.Domain.Models.Accounts;
using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeauProject.Restaurant.Data.EntityValidator.AccountsValidator
{
    public class AccountDetailTranslationValidator : IEntityTypeConfiguration<AccountDetailTranslation>
    {
        public void Configure(EntityTypeBuilder<AccountDetailTranslation> builder)
        {
            builder.ToTable("AccountDetailTranslations");

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
