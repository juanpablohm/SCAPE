using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCAPE.Domain.Entities;
using System;

namespace SCAPE.Infraestructure.Context.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id);


            entity.HasIndex(e => e.Email)
                .HasName("IX_EMAIL")
                .IsUnique()
                .HasFilter("([email] IS NOT NULL)");

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(20);


            entity.Property(e => e.Role)
                .IsRequired()
                .HasColumnName("role")
                .HasMaxLength(20);
        }
    }
}
