using PatientSystem.DTOs;

namespace PatientSystem.Business.Interfaces;

public interface IPatientService : IBaseCrudService<PatientReadDto, PatientCreateDto, PatientUpdateDto>
{
    Task<PatientReadDto?> GetByDocumentNumberAsync(string documentNumber);
}
