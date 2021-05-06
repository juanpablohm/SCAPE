using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCAPE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCAPE.Infraestructure.Context.Configuration
{
    class WorkPlaceConfiguration : IEntityTypeConfiguration<WorkPlace>
    {
        public void Configure(EntityTypeBuilder<WorkPlace> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Address)
                .HasColumnName("address")
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.Property(e => e.FaceListId)
               .HasColumnName("faceListId")
               .HasMaxLength(500)
               .IsUnicode(false);

            entity.Property(e => e.LatitudePosition)
                .HasColumnName("latitudePosition")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.LongitudePosition)
                .HasColumnName("longitudePosition")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(1000)
                .IsUnicode(false);
        }
    }
}
