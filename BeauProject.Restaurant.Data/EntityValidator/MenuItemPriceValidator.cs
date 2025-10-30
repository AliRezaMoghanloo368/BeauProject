using BeauProject.Restaurant.Domain.Models.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Restaurant.Data.EntityValidator
{
    public class MenuItemPriceValidator : IEntityTypeConfiguration<MenuItemPrice>
    {
        public void Configure(EntityTypeBuilder<MenuItemPrice> builder)
        {
            //builder.ToTable("MenuItemPrices");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CurrencyCode)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValue("IRR");

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.StartAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne<FoodItem>()
                   .WithMany() // می‌تونی Navigation اضافه کنی اگر خواستی
                   .HasForeignKey(x => x.MenuItemId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
