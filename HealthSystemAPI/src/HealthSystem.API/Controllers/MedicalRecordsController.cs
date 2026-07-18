using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class MedicalRecordsController : CrudControllerBase<MedicalRecordReadDto, MedicalRecordCreateDto, MedicalRecordUpdateDto>
{
    private readonly IMedicalRecordService _medicalRecordService;

    public MedicalRecordsController(IMedicalRecordService medicalRecordService) : base(medicalRecordService)
    {
        _medicalRecordService = medicalRecordService;
    }

    [HttpGet("patient/{patientId:int}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<MedicalRecordReadDto>>>> GetByPatient(int patientId)
    {
        var records = await _medicalRecordService.GetByPatientIdAsync(patientId);
        return Ok(ApiResponse<IEnumerable<MedicalRecordReadDto>>.Ok(records));
    }
}
