using PatientSystem.DTOs;

namespace PatientSystem.Business.Interfaces;

public interface IDoctorService : IBaseCrudService<DoctorReadDto, DoctorCreateDto, DoctorUpdateDto>
{
    Task<IEnumerable<DoctorReadDto>> GetBySpecialtyAsync(string specialty);
}
