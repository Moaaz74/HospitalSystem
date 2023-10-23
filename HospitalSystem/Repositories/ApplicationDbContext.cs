
using HospitalSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HospitalSystem.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.PatientAppointment)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.DoctorAppointments)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PatientReport>()
                .HasOne(pr => pr.Doctor)
                .WithOne(d => d.DoctorReport)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<PatientReport>()
                .HasOne(pr => pr.Patient)
                .WithMany(p => p.PatientReports)
                .OnDelete(DeleteBehavior.NoAction);
                
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Department> Departments { get; set; }  
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }
        public DbSet<PatientReport> PatientReports { get; set; }
        public DbSet<Lab> Labs { get; set; }

    }
}
