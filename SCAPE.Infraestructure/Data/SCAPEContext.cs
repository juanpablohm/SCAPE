using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SCAPE.Infraestructure.Data
{
    public partial class SCAPEContext : DbContext
    {
        public SCAPEContext()
        {
        }

        public SCAPEContext(DbContextOptions<SCAPEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeWorkPlace> EmployeeWorkPlace { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<WorkPlace> WorkPlace { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SCAPE;Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.DocumentId)
                    .HasName("UQ__Employee__EFAAAD84910DD433")
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
                    .IsRequired()
                    .HasColumnName("sex")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<EmployeeWorkPlace>(entity =>
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
            });

            modelBuilder.Entity<Image>(entity =>
            {
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
            });

            modelBuilder.Entity<WorkPlace>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(1000)
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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
