using PatientSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PatientSystem.DataAccess;

public class PatientSystemDbContext : DbContext
{
    public PatientSystemDbContext(DbContextOptions<PatientSystemDbContext> options) : base(options) { }

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Insurance> Insurances => Set<Insurance>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();
    public DbSet<Diagnosis> Diagnoses => Set<Diagnosis>();
    public DbSet<Treatment> Treatments => Set<Treatment>();
    public DbSet<Medication> Medications => Set<Medication>();
    public DbSet<Prescription> Prescriptions => Set<Prescription>();

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        modelBuilder.Entity<Patient>()
            .HasIndex(p => p.DocumentNumber).IsUnique();

        modelBuilder.Entity<Patient>()
            .HasOne(p => p.Insurance)
            .WithMany(i => i.Patients)
            .HasForeignKey(p => p.InsuranceId)
            .OnDelete(DeleteBehavior.SetNull);

   
        modelBuilder.Entity<Address>()
            .HasOne(a => a.Patient)
            .WithOne(p => p.Address)
            .HasForeignKey<Address>(a => a.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<Doctor>()
            .HasOne(d => d.Department)
            .WithMany(dep => dep.Doctors)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Doctor>()
            .HasIndex(d => d.LicenseNumber).IsUnique();

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MedicalRecord>()
            .HasOne(m => m.Patient)
            .WithMany(p => p.MedicalRecords)
            .HasForeignKey(m => m.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MedicalRecord>()
            .HasOne(m => m.Appointment)
            .WithOne(a => a.MedicalRecord)
            .HasForeignKey<MedicalRecord>(m => m.AppointmentId)
            .OnDelete(DeleteBehavior.SetNull);

       
        modelBuilder.Entity<Diagnosis>()
            .HasOne(d => d.MedicalRecord)
            .WithMany(m => m.Diagnoses)
            .HasForeignKey(d => d.MedicalRecordId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<Treatment>()
            .HasOne(t => t.Diagnosis)
            .WithMany(d => d.Treatments)
            .HasForeignKey(t => t.DiagnosisId)
            .OnDelete(DeleteBehavior.Cascade);

       
        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Treatment)
            .WithMany(t => t.Prescriptions)
            .HasForeignKey(p => p.TreatmentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Medication)
            .WithMany(m => m.Prescriptions)
            .HasForeignKey(p => p.MedicationId)
            .OnDelete(DeleteBehavior.Restrict);

       
        modelBuilder.Entity<Patient>().HasQueryFilter(p => p.IsActive);
        modelBuilder.Entity<Doctor>().HasQueryFilter(d => d.IsActive);
        modelBuilder.Entity<Department>().HasQueryFilter(d => d.IsActive);
        modelBuilder.Entity<Insurance>().HasQueryFilter(i => i.IsActive);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<Domain.Common.BaseEntity>())
        {
            if (entry.State == EntityState.Modified)
                entry.Entity.UpdatedAt = DateTime.UtcNow;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
