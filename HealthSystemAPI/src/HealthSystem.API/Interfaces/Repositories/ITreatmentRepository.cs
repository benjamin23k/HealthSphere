using PatientSystem.Domain.Entities;

namespace PatientSystem.Domain.Interfaces;

public interface ITreatmentRepository : IGenericRepository<Treatment>
{
    Task<IEnumerable<Treatment>> GetByDiagnosisIdAsync(int diagnosisId);
}
