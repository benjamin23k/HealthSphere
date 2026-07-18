using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;
using PatientSystem.DataAccess.Repositories;

namespace PatientSystem.DataAccess;


public class UnitOfWork : IUnitOfWork
{
    private readonly PatientSystemDbContext _context;

    public IGenericRepository<Department> Departments { get; }
    public IGenericRepository<Insurance> Insurances { get; }
    public IGenericRepository<Address> Addresses { get; }
    public IGenericRepository<Medication> Medications { get; }
    public IGenericRepository<Diagnosis> Diagnoses { get; }
    public IGenericRepository<Treatment> Treatments { get; }
    public IGenericRepository<Prescription> Prescriptions { get; }
    public IGenericRepository<MedicalRecord> MedicalRecords { get; }

    public IPatientRepository Patients { get; }
    public IDoctorRepository Doctors { get; }
    public IAppointmentRepository Appointments { get; }

    public UnitOfWork(PatientSystemDbContext context)
    {
        _context = context;

        Departments = new GenericRepository<Department>(_context);
        Insurances = new GenericRepository<Insurance>(_context);
        Addresses = new GenericRepository<Address>(_context);
        Medications = new GenericRepository<Medication>(_context);
        Diagnoses = new GenericRepository<Diagnosis>(_context);
        Treatments = new GenericRepository<Treatment>(_context);
        Prescriptions = new GenericRepository<Prescription>(_context);
        MedicalRecords = new GenericRepository<MedicalRecord>(_context);

        Patients = new PatientRepository(_context);
        Doctors = new DoctorRepository(_context);
        Appointments = new AppointmentRepository(_context);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}
