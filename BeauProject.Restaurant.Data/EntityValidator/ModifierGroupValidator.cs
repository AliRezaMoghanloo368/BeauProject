using BeauProject.Restaurant.Domain.Models.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeauProject.Restaurant.Data.EntityValidator
{
    public class ModifierGroupValidator : IEntityTypeConfiguration<ModifierGroup>
    {
        public void Configure(EntityTypeBuilder<ModifierGroup> builder)
        {
            //builder.ToTable("ModifierGroups");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.MinSelection)
                   .IsRequired()
                   .HasDefaultValue(0);

            builder.Property(x => x.MaxSelection)
                   .IsRequired()
                   .HasDefaultValue(0);

            builder.HasOne<FoodItem>()
                   .WithMany(f => f.ModifierGroups) // باید Navigation تو FoodItem اضافه بشه
                   .HasForeignKey(x => x.MenuItemId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
