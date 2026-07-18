using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class DepartmentsController : CrudControllerBase<DepartmentReadDto, DepartmentCreateDto, DepartmentUpdateDto>
{
    public DepartmentsController(IBaseCrudService<DepartmentReadDto, DepartmentCreateDto, DepartmentUpdateDto> service)
        : base(service) { }
}
