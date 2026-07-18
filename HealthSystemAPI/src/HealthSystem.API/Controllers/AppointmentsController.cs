using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class AppointmentsController : CrudControllerBase<AppointmentReadDto, AppointmentCreateDto, AppointmentUpdateDto>
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService) : base(appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet("rango")]
    public async Task<ActionResult<ApiResponse<IEnumerable<AppointmentReadDto>>>> GetByDateRange(
        [FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        var appointments = await _appointmentService.GetByDateRangeAsync(from, to);
        return Ok(ApiResponse<IEnumerable<AppointmentReadDto>>.Ok(appointments));
    }
}
