using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCAPE.Domain.Entities;
using System;

namespace SCAPE.Infraestructure.Context.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.DocumentId)
                    .HasName("UQ__Employee__EFAAAD84A30B3E3E")
                    .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.DateBirth)
                .HasColumnName("dateBirth")
                .HasColumnType("datetime");

            entity.Property(e => e.DocumentId)
                .IsRequired()
                .HasColumnName("documentId")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("firstName")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("lastName")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Sex)       
                .HasColumnName("sex")
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        }
    }
}
