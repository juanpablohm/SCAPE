using Microsoft.EntityFrameworkCore;
using SCAPE.Domain.Entities;
using SCAPE.Infraestructure.Context.Configuration;

namespace SCAPE.Infraestructure.Context
{
    public partial class SCAPEDBContext : DbContext
    {
        public SCAPEDBContext()
        {
        }

        public SCAPEDBContext(DbContextOptions<SCAPEDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeWorkPlace> EmployeeWorkPlace { get; set; }
        public virtual DbSet<EmployeeImage> Image { get; set; }
        public virtual DbSet<WorkPlace> WorkPlace { get; set; }
        public virtual DbSet<User> User { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AttendanceConfiguration());

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.ApplyConfiguration(new EmployeeWorkPlaceConfiguration());

            modelBuilder.ApplyConfiguration(new ImageConfiguration());

            modelBuilder.ApplyConfiguration(new WorkPlaceConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
