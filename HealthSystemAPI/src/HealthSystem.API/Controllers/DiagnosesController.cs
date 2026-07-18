using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class DiagnosesController : CrudControllerBase<DiagnosisReadDto, DiagnosisCreateDto, DiagnosisUpdateDto>
{
    private readonly IDiagnosisService _diagnosisService;

    public DiagnosesController(IDiagnosisService diagnosisService) : base(diagnosisService)
    {
        _diagnosisService = diagnosisService;
    }

    [HttpGet("medical-record/{medicalRecordId:int}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<DiagnosisReadDto>>>> GetByMedicalRecord(int medicalRecordId)
    {
        var diagnoses = await _diagnosisService.GetByMedicalRecordIdAsync(medicalRecordId);
        return Ok(ApiResponse<IEnumerable<DiagnosisReadDto>>.Ok(diagnoses));
    }
}
