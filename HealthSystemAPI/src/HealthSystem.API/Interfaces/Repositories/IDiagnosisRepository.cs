using PatientSystem.Domain.Entities;

namespace PatientSystem.Domain.Interfaces;

public interface IDiagnosisRepository : IGenericRepository<Diagnosis>
{
    Task<IEnumerable<Diagnosis>> GetByMedicalRecordIdAsync(int medicalRecordId);
}
