using BeauProject.Shared.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Shared.Data.EntityValidator
{
    public class GroupProductsValidator : IEntityTypeConfiguration<GroupProducts>
    {
        public void Configure(EntityTypeBuilder<GroupProducts> builder)
        {
            builder.ToTable("GroupProducts");

            // ستون Id
            builder.HasKey(p => p.Id);

            // ستون Name
            builder.Property(g => g.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(g => g.Products)       // اینجا Products مربوط به GroupProducts هست
                   .WithOne(p => p.GroupProducts)  // اینجا GroupProducts مربوط به Products هست
                   .HasForeignKey(p => p.GroupProductsId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
