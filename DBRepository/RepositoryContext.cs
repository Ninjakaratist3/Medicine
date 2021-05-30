using Microsoft.EntityFrameworkCore;
using Models.Configurations;
using Models.Entities;

namespace DBRepository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Clinic> Clinics { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<BodyParameters> HealthParameters { get; set; }

        public DbSet<SmtpConfiguration> SmtpConfigurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserRole adminRole = new UserRole { Id = 1, Name = "admin" };
            UserRole userRole = new UserRole { Id = 2, Name = "user" };
            UserRole doctorRole = new UserRole { Id = 3, Name = "doctor" };

            modelBuilder.Entity<UserRole>().HasData(new UserRole[] { adminRole, userRole, doctorRole });
            modelBuilder.Entity<SmtpConfiguration>().HasData(new SmtpConfiguration() { Id = 1, Email = "", Host = "", Password = "", Port = 0, UseSsl = false });

            base.OnModelCreating(modelBuilder);
        }
    }
}
