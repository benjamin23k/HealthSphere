using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class AddressesController : CrudControllerBase<AddressReadDto, AddressCreateDto, AddressUpdateDto>
{
    private readonly IAddressService _addressService;

    public AddressesController(IAddressService addressService) : base(addressService)
    {
        _addressService = addressService;
    }

    [HttpGet("patient/{patientId:int}")]
    public async Task<ActionResult<ApiResponse<AddressReadDto>>> GetByPatientId(int patientId)
    {
        var address = await _addressService.GetByPatientIdAsync(patientId);
        if (address is null)
            return NotFound(ApiResponse<AddressReadDto>.Fail("In the directional encounter for that patient."));

        return Ok(ApiResponse<AddressReadDto>.Ok(address));
    }
}
