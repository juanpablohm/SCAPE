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
        public void Configure(EntityTypeBuilder<WorkPlace> builder)
        {
            builder.Property(e => e.Id)
                   .HasColumnName("id")
                   .ValueGeneratedNever();

            builder.Property(e => e.Address)
                .IsRequired()
                .HasColumnName("address")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.LatitudePosition)
                .HasColumnName("latitudePosition")
                .HasColumnType("decimal(12, 9)");

            builder.Property(e => e.LongitudePosition)
                .HasColumnName("longitudePosition")
                .HasColumnType("decimal(12, 9)");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}
