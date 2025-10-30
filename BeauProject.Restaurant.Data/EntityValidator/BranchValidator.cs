using BeauProject.Restaurant.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Restaurant.Data.EntityValidator
{
    public class BranchValidator : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Code)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Locale)
                .HasMaxLength(10);

            builder.Property(b => b.Address)
                .HasMaxLength(250);

            builder.HasOne(b => b.Restaurant)
                .WithMany(r => r.Branches)
                .HasForeignKey(b => b.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
