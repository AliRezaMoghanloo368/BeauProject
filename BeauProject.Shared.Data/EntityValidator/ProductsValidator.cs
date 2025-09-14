using BeauProject.Shared.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Shared.Data.EntityValidator
{
    public class ProductsValidator : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products");

            // ستون Id
            builder.HasKey(p => p.Id);

            // ستون Code
            builder.Property(p => p.Code)
                   .IsRequired()         // مقدار اجباری
                   .HasMaxLength(50);    // حداکثر 50 کاراکتر

            // ستون Name
            builder.Property(p => p.Name)
                   .IsRequired()         // مقدار اجباری
                   .HasMaxLength(100);   // حداکثر 100 کاراکتر

            // ستون Price
            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,4)")  // دقت decimal
                   .IsRequired();

            builder.HasOne(p => p.GroupProducts)
                   .WithMany(g => g.Products)
                   .HasForeignKey(p => p.GroupProductsId)
                   //Restrict: اگر گروه مربوطه حذف شد محصول مربوط به آن حذف نشه و خطا بده
                   .OnDelete(DeleteBehavior.Restrict); // یا Cascade یا NoAction

        }
    }
}
