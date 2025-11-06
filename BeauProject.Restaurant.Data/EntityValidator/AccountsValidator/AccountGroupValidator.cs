using BeauProject.Restaurant.Domain.Models.Accounts;
using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Restaurant.Data.EntityValidator.AccountsValidator
{
    public class AccountGroupValidator : IEntityTypeConfiguration<AccountGroup>
    {
        public void Configure(EntityTypeBuilder<AccountGroup> builder)
        {
            builder.ToTable("AccountGroups");   

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Code)
                  .HasMaxLength(50)
                  .IsRequired();

            builder.Property(e => e.IsActive)
                  .HasDefaultValue(true);

            // رابطه با SubGroups (بدون cascade delete)
            builder.HasMany(g => g.SubGroups)
                  .WithOne(sg => sg.Group)
                  .HasForeignKey(sg => sg.GroupId)
                  .OnDelete(DeleteBehavior.Restrict);

            // رابطه با Translations (با cascade delete)
            builder.HasMany(g => g.Translations)
                  .WithOne(t => t.AccountGroup)
                  .HasForeignKey(t => t.AccountGroupId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
