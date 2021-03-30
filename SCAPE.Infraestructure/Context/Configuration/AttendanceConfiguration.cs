using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCAPE.Domain.Entities;

namespace SCAPE.Infraestructure.Context.Configuration
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.Property(e => e.Id)
                   .HasColumnName("id")
                   .ValueGeneratedNever();

            builder.Property(e => e.Date)
                .HasColumnName("date")
                .HasColumnType("datetime");

            builder.Property(e => e.IdEmployee).HasColumnName("idEmployee");

            builder.Property(e => e.Type)
                .IsRequired()
                .HasColumnName("type")
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            builder.HasOne(d => d.IdEmployeeNavigation)
                .WithMany(p => p.Attendance)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_idEmployee");
        }
    }
}
