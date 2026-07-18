using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class PatientsController : CrudControllerBase<PatientReadDto, PatientCreateDto, PatientUpdateDto>
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService) : base(patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("document/{documentNumber}")]
    public async Task<ActionResult<ApiResponse<PatientReadDto>>> GetByDocument(string documentNumber)
    {
        var patient = await _patientService.GetByDocumentNumberAsync(documentNumber);
        if (patient is null)
            return NotFound(ApiResponse<PatientReadDto>.Fail("No se encontro un paciente con ese documento."));

        return Ok(ApiResponse<PatientReadDto>.Ok(patient));
    }
}
