using PatientSystem.DTOs;

namespace PatientSystem.Business.Interfaces;

public interface IMedicationService : IBaseCrudService<MedicationReadDto, MedicationCreateDto, MedicationUpdateDto>
{
    Task<IEnumerable<MedicationReadDto>> SearchByNameAsync(string name);
}
