using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class PrescriptionsController : CrudControllerBase<PrescriptionReadDto, PrescriptionCreateDto, PrescriptionUpdateDto>
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionsController(IPrescriptionService prescriptionService) : base(prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpGet("treatment/{treatmentId:int}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<PrescriptionReadDto>>>> GetByTreatment(int treatmentId)
    {
        var prescriptions = await _prescriptionService.GetByTreatmentIdAsync(treatmentId);
        return Ok(ApiResponse<IEnumerable<PrescriptionReadDto>>.Ok(prescriptions));
    }
}
