using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class InsurancesController : CrudControllerBase<InsuranceReadDto, InsuranceCreateDto, InsuranceUpdateDto>
{
    public InsurancesController(IBaseCrudService<InsuranceReadDto, InsuranceCreateDto, InsuranceUpdateDto> service)
        : base(service) { }
}
