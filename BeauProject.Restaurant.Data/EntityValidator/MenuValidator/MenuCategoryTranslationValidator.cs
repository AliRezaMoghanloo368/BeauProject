using BeauProject.Restaurant.Domain.Models.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Restaurant.Data.EntityValidator.MenuValidator
{
    public class MenuCategoryTranslationValidator : IEntityTypeConfiguration<MenuCategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<MenuCategoryTranslation> builder)
        {
            //builder.ToTable("MenuCategoryTranslations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Locale)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValue("fa-IR");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            // 🔑 Unique Index برای جلوگیری از تکراری شدن ترجمه
            builder.HasIndex(x => new { x.CategoryId, x.Locale })
                   .IsUnique();

            // 🔗 Navigation
            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Translations)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
