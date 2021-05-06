using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCAPE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCAPE.Infraestructure.Context.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<EmployeeImage>
    {

        public void Configure(EntityTypeBuilder<EmployeeImage> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Image");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

            entity.Property(e => e.Image).HasColumnName("image");

            entity.Property(e => e.PersistenceFaceId)
                .HasColumnName("persistenceFaceId")
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
