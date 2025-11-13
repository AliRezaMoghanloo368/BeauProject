using BeauProject.Accounting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Accounting.Data.EntityValidator
{
    public class AccountSubGroupValidator : IEntityTypeConfiguration<AccountSubGroup>
    {
        public void Configure(EntityTypeBuilder<AccountSubGroup> builder)
        {
            builder.ToTable("AccountSubGroups");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Code)
                  .HasMaxLength(50)
                  .IsRequired();

            builder.Property(e => e.IsActive)
                  .HasDefaultValue(true);

            // رابطه با Details (بدون cascade delete)
            builder.HasMany(sg => sg.Details)
                  .WithOne(d => d.SubGroup)
                  .HasForeignKey(d => d.SubGroupId)
                  .OnDelete(DeleteBehavior.Restrict);

            // رابطه با Translations (با cascade delete)
            builder.HasMany(sg => sg.Translations)
                  .WithOne(t => t.AccountSubGroup)
                  .HasForeignKey(t => t.AccountSubGroupId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
