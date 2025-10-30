
using BeauProject.Restaurant.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeauProject.Restaurant.Data.EntityValidator
{
    public class TableValidator : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            //builder.ToTable("Tables");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TableCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Capacity)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.HasOne<Branch>()
                   .WithMany(b => b.Tables)
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
