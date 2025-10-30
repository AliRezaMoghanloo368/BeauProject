using BeauProject.Restaurant.Domain.Models.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Restaurant.Data.EntityValidator.MenuValidator
{
    public class FoodAddonOptionValidator : IEntityTypeConfiguration<FoodAddonOption>
    {
        public void Configure(EntityTypeBuilder<FoodAddonOption> builder)
        {
            builder.ToTable("FoodAddonOptions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,4)");

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(x => x.FoodItem)
                .WithMany(x => x.AddonOptions)
                .HasForeignKey(x => x.FoodItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
