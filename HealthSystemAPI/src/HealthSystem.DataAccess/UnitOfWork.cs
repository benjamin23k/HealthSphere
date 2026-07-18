using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;
using PatientSystem.DataAccess.Repositories;

namespace PatientSystem.DataAccess;


public class UnitOfWork : IUnitOfWork
{
    private readonly PatientSystemDbContext _context;

    public IDepartmentRepository Departments { get; }
    public IInsuranceRepository Insurances { get; }
    public IAddressRepository Addresses { get; }
    public IMedicationRepository Medications { get; }
    public IDiagnosisRepository Diagnoses { get; }
    public ITreatmentRepository Treatments { get; }
    public IPrescriptionRepository Prescriptions { get; }
    public IMedicalRecordRepository MedicalRecords { get; }

    public IPatientRepository Patients { get; }
    public IDoctorRepository Doctors { get; }
    public IAppointmentRepository Appointments { get; }

    public UnitOfWork(PatientSystemDbContext context)
    {
        _context = context;

        Departments = new DepartmentRepository(_context);
        Insurances = new InsuranceRepository(_context);
        Addresses = new AddressRepository(_context);
        Medications = new MedicationRepository(_context);
        Diagnoses = new DiagnosisRepository(_context);
        Treatments = new TreatmentRepository(_context);
        Prescriptions = new PrescriptionRepository(_context);
        MedicalRecords = new MedicalRecordRepository(_context);

        Patients = new PatientRepository(_context);
        Doctors = new DoctorRepository(_context);
        Appointments = new AppointmentRepository(_context);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}
