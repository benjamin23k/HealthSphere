using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class MedicationsController : CrudControllerBase<MedicationReadDto, MedicationCreateDto, MedicationUpdateDto>
{
    private readonly IMedicationService _medicationService;

    public MedicationsController(IMedicationService medicationService) : base(medicationService)
    {
        _medicationService = medicationService;
    }

    [HttpGet("search")]
    public async Task<ActionResult<ApiResponse<IEnumerable<MedicationReadDto>>>> Search([FromQuery] string name)
    {
        var medications = await _medicationService.SearchByNameAsync(name);
        return Ok(ApiResponse<IEnumerable<MedicationReadDto>>.Ok(medications));
    }
}
