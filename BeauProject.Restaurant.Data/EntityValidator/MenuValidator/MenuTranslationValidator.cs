using BeauProject.Restaurant.Domain.Models.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeauProject.Restaurant.Data.EntityValidator.MenuValidator
{
    public class MenuTranslationValidator : IEntityTypeConfiguration<MenuTranslation>
    {
        public void Configure(EntityTypeBuilder<MenuTranslation> builder)
        {
            //builder.ToTable("MenuTranslations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.EntityType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LanguageCode)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(x => new { x.EntityType, x.EntityId, x.LanguageCode })
                .IsUnique(); // 🔑 اطمینان از یکتا بودن ترجمه
        }
    }
}
