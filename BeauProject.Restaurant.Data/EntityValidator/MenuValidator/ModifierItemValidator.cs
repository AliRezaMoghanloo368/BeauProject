using BeauProject.Restaurant.Domain.Models.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Restaurant.Data.EntityValidator.MenuValidator
{
    public class ModifierItemValidator : IEntityTypeConfiguration<ModifierItem>
    {
        public void Configure(EntityTypeBuilder<ModifierItem> builder)
        {
            //builder.ToTable("ModifierItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Price)
                   .HasColumnType("decimal(18,4)");

            builder.Property(x => x.TrackInventory)
                   .HasDefaultValue(false);

            builder.HasOne<ModifierGroup>()
                   .WithMany(g => g.Modifiers) // Navigation تو ModifierGroup
                   .HasForeignKey(x => x.GroupId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
