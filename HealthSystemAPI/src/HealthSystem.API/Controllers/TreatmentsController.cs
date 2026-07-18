using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class TreatmentsController : CrudControllerBase<TreatmentReadDto, TreatmentCreateDto, TreatmentUpdateDto>
{
    public TreatmentsController(IBaseCrudService<TreatmentReadDto, TreatmentCreateDto, TreatmentUpdateDto> service)
        : base(service) { }
}
