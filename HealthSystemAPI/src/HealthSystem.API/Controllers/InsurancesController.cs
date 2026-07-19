using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class InsurancesController : CrudControllerBase<InsuranceReadDto, InsuranceCreateDto, InsuranceUpdateDto>
{
    private readonly IInsuranceService _insuranceService;

    public InsurancesController(IInsuranceService insuranceService) : base(insuranceService)
    {
        _insuranceService = insuranceService;
    }

    [HttpGet("provider/{providerName}")]
    public async Task<ActionResult<ApiResponse<InsuranceReadDto>>> GetByProvider(string providerName)
    {
        var insurance = await _insuranceService.GetByProviderNameAsync(providerName);
        if (insurance is null)
            return NotFound(ApiResponse<InsuranceReadDto>.Fail("In the event of that insurer."));

        return Ok(ApiResponse<InsuranceReadDto>.Ok(insurance));
    }
}
