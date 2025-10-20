using BeauProject.Restaurant.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Restaurant.Data.EntityValidator
{
    public class RestaurantValidator : IEntityTypeConfiguration<RestaurantEntity>
    {
        public void Configure(EntityTypeBuilder<RestaurantEntity> builder)
        {
            //builder.ToTable("Restaurants");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Code)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(x => x.Code).IsUnique();

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.DefaultCurrency)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(x => x.TimeZone).HasMaxLength(50);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(x => x.UpdatedAt).IsRequired(false);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
