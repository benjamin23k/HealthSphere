using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class DiagnosesController : CrudControllerBase<DiagnosisReadDto, DiagnosisCreateDto, DiagnosisUpdateDto>
{
    public DiagnosesController(IBaseCrudService<DiagnosisReadDto, DiagnosisCreateDto, DiagnosisUpdateDto> service)
        : base(service) { }
}
