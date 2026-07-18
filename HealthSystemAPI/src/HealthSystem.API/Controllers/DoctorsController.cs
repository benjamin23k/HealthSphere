using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class DoctorsController : CrudControllerBase<DoctorReadDto, DoctorCreateDto, DoctorUpdateDto>
{
    private readonly IDoctorService _doctorService;

    public DoctorsController(IDoctorService doctorService) : base(doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet("especialidad/{specialty}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<DoctorReadDto>>>> GetBySpecialty(string specialty)
    {
        var doctors = await _doctorService.GetBySpecialtyAsync(specialty);
        return Ok(ApiResponse<IEnumerable<DoctorReadDto>>.Ok(doctors));
    }
}
