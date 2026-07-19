using PatientSystem.DTOs;

namespace PatientSystem.Business.Interfaces;

public interface ITreatmentService : IBaseCrudService<TreatmentReadDto, TreatmentCreateDto, TreatmentUpdateDto>
{
    Task<IEnumerable<TreatmentReadDto>> GetByDiagnosisIdAsync(int diagnosisId);
}
