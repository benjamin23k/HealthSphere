using AutoMapper;
using PatientSystem.Business.Interfaces;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.Business.Services;

public class DepartmentService : BaseCrudService<Department, DepartmentReadDto, DepartmentCreateDto, DepartmentUpdateDto>, IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork.Departments, unitOfWork, mapper)
    {
        _departmentRepository = unitOfWork.Departments;
    }

    public override async Task<DepartmentReadDto> CreateAsync(DepartmentCreateDto dto)
    {
        var existing = await _departmentRepository.GetByNameAsync(dto.Name);
        if (existing is not null)
            throw new InvalidOperationException($"Ya existe un departamento con el nombre '{dto.Name}'.");

        return await base.CreateAsync(dto);
    }
}
