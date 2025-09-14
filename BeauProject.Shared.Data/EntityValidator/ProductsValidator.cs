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

            builder.HasOne(p => p.GroupProducts)
                   .WithMany(g => g.Products)
                   .HasForeignKey(p => p.GroupProductsId)
                   .OnDelete(DeleteBehavior.Restrict); // یا Cascade یا NoAction
        }
    }
}
