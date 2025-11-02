using BeauProject.Restaurant.Domain.Models.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Restaurant.Data.EntityValidator.MenuValidator
{
    public class FoodItemValidator : IEntityTypeConfiguration<FoodItem>
    {
        public void Configure(EntityTypeBuilder<FoodItem> builder)
        {
            //builder.ToTable("FoodItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,4)");

            builder.Property(x => x.Currency)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValue("IRR");

            builder.Property(x => x.IsAvailable)
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(x => x.Category)
                .WithMany(x => x.FoodItems)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Restaurant)
                .WithMany(x => x.FoodItems)
                .HasForeignKey(x => x.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(b => b.Category)
            //    .WithMany(r => r.FoodItems)
            //    .HasForeignKey(b => b.CategoryId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}