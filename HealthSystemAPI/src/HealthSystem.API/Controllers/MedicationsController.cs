using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class MedicationsController : CrudControllerBase<MedicationReadDto, MedicationCreateDto, MedicationUpdateDto>
{
    public MedicationsController(IBaseCrudService<MedicationReadDto, MedicationCreateDto, MedicationUpdateDto> service)
        : base(service) { }
}
