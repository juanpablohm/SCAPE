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

        public void Configure(EntityTypeBuilder<Image> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

            entity.Property(e => e.Url)
                .IsRequired()
                .HasColumnName("url")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmployeeNavigation)
                .WithMany(p => p.Image)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeImage");
        }
    }
}
