using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class PrescriptionsController : CrudControllerBase<PrescriptionReadDto, PrescriptionCreateDto, PrescriptionUpdateDto>
{
    public PrescriptionsController(IBaseCrudService<PrescriptionReadDto, PrescriptionCreateDto, PrescriptionUpdateDto> service)
        : base(service) { }
}
