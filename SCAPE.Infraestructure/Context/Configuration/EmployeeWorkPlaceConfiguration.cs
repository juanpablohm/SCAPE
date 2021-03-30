using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCAPE.Domain.Entities;
using System;

namespace SCAPE.Infraestructure.Context.Configuration
{
    public class EmployeeWorkPlaceConfiguration : IEntityTypeConfiguration<EmployeeWorkPlace>
    {
        public void Configure(EntityTypeBuilder<EmployeeWorkPlace> entity)
        {
            entity.HasKey(e => new { e.IdEmployee, e.IdWorkPlace })
                    .HasName("PK_EmployeeWorkPlace");

            entity.ToTable("Employee_WorkPlace");

            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

            entity.Property(e => e.IdWorkPlace).HasColumnName("idWorkPlace");

            entity.Property(e => e.EndJobDate)
                .HasColumnName("endJobDate")
                .HasColumnType("datetime");

            entity.Property(e => e.Schedule)
                .IsRequired()
                .HasColumnName("schedule")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.StartJobDate)
                .HasColumnName("startJobDate")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdEmployeeNavigation)
                .WithMany(p => p.EmployeeWorkPlace)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeWorkPlace");

            entity.HasOne(d => d.IdWorkPlaceNavigation)
                .WithMany(p => p.EmployeeWorkPlace)
                .HasForeignKey(d => d.IdWorkPlace)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkPlace");
        }
    }
}
