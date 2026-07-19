using PatientSystem.DTOs;

namespace PatientSystem.Business.Interfaces;

public interface IDiagnosisService : IBaseCrudService<DiagnosisReadDto, DiagnosisCreateDto, DiagnosisUpdateDto>
{
    Task<IEnumerable<DiagnosisReadDto>> GetByMedicalRecordIdAsync(int medicalRecordId);
}
