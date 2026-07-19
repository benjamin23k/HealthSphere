using PatientSystem.Domain.Entities;

namespace PatientSystem.Domain.Interfaces;

public interface IMedicalRecordRepository : IGenericRepository<MedicalRecord>
{
    Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId);
}
