using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class TreatmentsController : CrudControllerBase<TreatmentReadDto, TreatmentCreateDto, TreatmentUpdateDto>
{
    private readonly ITreatmentService _treatmentService;

    public TreatmentsController(ITreatmentService treatmentService) : base(treatmentService)
    {
        _treatmentService = treatmentService;
    }

    [HttpGet("diagnosis/{diagnosisId:int}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<TreatmentReadDto>>>> GetByDiagnosis(int diagnosisId)
    {
        var treatments = await _treatmentService.GetByDiagnosisIdAsync(diagnosisId);
        return Ok(ApiResponse<IEnumerable<TreatmentReadDto>>.Ok(treatments));
    }
}
