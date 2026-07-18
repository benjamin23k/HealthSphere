using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class MedicalRecordsController : CrudControllerBase<MedicalRecordReadDto, MedicalRecordCreateDto, MedicalRecordUpdateDto>
{
    public MedicalRecordsController(IBaseCrudService<MedicalRecordReadDto, MedicalRecordCreateDto, MedicalRecordUpdateDto> service)
        : base(service) { }
}
