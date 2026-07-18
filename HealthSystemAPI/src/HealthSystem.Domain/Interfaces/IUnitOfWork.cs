using PatientSystem.Domain.Entities;

namespace PatientSystem.Domain.Interfaces;


public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Department> Departments { get; }
    IGenericRepository<Insurance> Insurances { get; }
    IGenericRepository<Address> Addresses { get; }
    IGenericRepository<Medication> Medications { get; }
    IGenericRepository<Diagnosis> Diagnoses { get; }
    IGenericRepository<Treatment> Treatments { get; }
    IGenericRepository<Prescription> Prescriptions { get; }
    IGenericRepository<MedicalRecord> MedicalRecords { get; }

    IPatientRepository Patients { get; }
    IDoctorRepository Doctors { get; }
    IAppointmentRepository Appointments { get; }

    Task<int> SaveChangesAsync();
}
