using PatientSystem.DTOs;

namespace PatientSystem.Business.Interfaces;

public interface IMedicalRecordService : IBaseCrudService<MedicalRecordReadDto, MedicalRecordCreateDto, MedicalRecordUpdateDto>
{
    Task<IEnumerable<MedicalRecordReadDto>> GetByPatientIdAsync(int patientId);
}
