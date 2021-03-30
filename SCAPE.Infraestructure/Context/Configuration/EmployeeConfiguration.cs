using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCAPE.Domain.Entities;
using System;

namespace SCAPE.Infraestructure.Context.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasIndex(e => e.DocumentId)
                   .HasName("UQ__Employee__EFAAAD845830720A")
                   .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.DateBirth)
                .HasColumnName("dateBirth")
                .HasColumnType("datetime");

            builder.Property(e => e.DocumentId)
                .IsRequired()
                .HasColumnName("documentId")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("firstName")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("lastName")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Sex)
                .HasColumnName("sex")
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        }
    }
}
