using PatientSystem.DTOs;

namespace PatientSystem.Business.Interfaces;

public interface IDepartmentService : IBaseCrudService<DepartmentReadDto, DepartmentCreateDto, DepartmentUpdateDto>
{
}
