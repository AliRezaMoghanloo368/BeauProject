using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BeauProject.Identity.Domain.Models;

namespace BeauProject.Identity.Data.EntityValidator
{
    public class UserValidator : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(512);
        }
    }
}
