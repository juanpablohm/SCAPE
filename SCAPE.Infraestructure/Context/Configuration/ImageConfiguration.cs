using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCAPE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCAPE.Infraestructure.Context.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {

        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.IdEmployee).HasColumnName("idEmployee");

            builder.Property(e => e.Url)
                .IsRequired()
                .HasColumnName("url")
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.HasOne(d => d.IdEmployeeNavigation)
                .WithMany(p => p.Image)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Image_idEmployee");
        }
    }
}
