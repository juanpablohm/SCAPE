using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCAPE.Domain.Entities;
using System;

namespace SCAPE.Infraestructure.Context.Configuration
{
    public class EmployeeWorkPlaceConfiguration : IEntityTypeConfiguration<EmployeeWorkPlace>
    {
        public void Configure(EntityTypeBuilder<EmployeeWorkPlace> builder)
        {
            builder.HasKey(e => new { e.IdEmployee, e.IdWorkPlace });

            builder.ToTable("Employee_WorkPlace");

            builder.Property(e => e.IdEmployee).HasColumnName("idEmployee");

            builder.Property(e => e.IdWorkPlace).HasColumnName("idWorkPlace");

            builder.Property(e => e.EndJobDate)
                .HasColumnName("endJobDate")
                .HasColumnType("datetime");

            builder.Property(e => e.Schedule)
                .IsRequired()
                .HasColumnName("schedule")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.StartJobDate)
                .HasColumnName("startJobDate")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdEmployeeNavigation)
                .WithMany(p => p.EmployeeWorkPlace)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_WorkPlace_idEmployee");

            builder.HasOne(d => d.IdWorkPlaceNavigation)
                .WithMany(p => p.EmployeeWorkPlace)
                .HasForeignKey(d => d.IdWorkPlace)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_WorkPlace_idWorkPlace");
        }
    }
}
