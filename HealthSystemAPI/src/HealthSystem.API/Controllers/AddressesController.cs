using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[Route("api/[controller]")]
public class AddressesController : CrudControllerBase<AddressReadDto, AddressCreateDto, AddressUpdateDto>
{
    public AddressesController(IBaseCrudService<AddressReadDto, AddressCreateDto, AddressUpdateDto> service)
        : base(service) { }
}
