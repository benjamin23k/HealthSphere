using PatientSystem.Domain.Entities;

namespace PatientSystem.Domain.Interfaces;


public interface IUnitOfWork : IDisposable
{
    IDepartmentRepository Departments { get; }
    IInsuranceRepository Insurances { get; }
    IAddressRepository Addresses { get; }
    IMedicationRepository Medications { get; }
    IDiagnosisRepository Diagnoses { get; }
    ITreatmentRepository Treatments { get; }
    IPrescriptionRepository Prescriptions { get; }
    IMedicalRecordRepository MedicalRecords { get; }

    IPatientRepository Patients { get; }
    IDoctorRepository Doctors { get; }
    IAppointmentRepository Appointments { get; }

    Task<int> SaveChangesAsync();
}
