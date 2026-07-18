using Microsoft.AspNetCore.Mvc;
using PatientSystem.Business.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.API.Controllers;

[ApiController]
public abstract class CrudControllerBase<TReadDto, TCreateDto, TUpdateDto> : ControllerBase
    where TReadDto : class
{
    protected readonly IBaseCrudService<TReadDto, TCreateDto, TUpdateDto> _service;

    protected CrudControllerBase(IBaseCrudService<TReadDto, TCreateDto, TUpdateDto> service)
    {
        _service = service;
    }

    [HttpGet]
    public virtual async Task<ActionResult<ApiResponse<IEnumerable<TReadDto>>>> GetAll()
    {
        var items = await _service.GetAllAsync();
        return Ok(ApiResponse<IEnumerable<TReadDto>>.Ok(items));
    }

    [HttpGet("{id:int}")]
    public virtual async Task<ActionResult<ApiResponse<TReadDto>>> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item is null)
            return NotFound(ApiResponse<TReadDto>.Fail($"No se encontro el registro con id {id}."));

        return Ok(ApiResponse<TReadDto>.Ok(item));
    }

    [HttpPost]
    public virtual async Task<ActionResult<ApiResponse<TReadDto>>> Create([FromBody] TCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ApiResponse<TReadDto>.Fail("Datos invalidos."));

        try
        {
            var created = await _service.CreateAsync(dto);
            return Ok(ApiResponse<TReadDto>.Ok(created, "Registro creado correctamente."));
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ApiResponse<TReadDto>.Fail(ex.Message));
        }
    }

    [HttpPut("{id:int}")]
    public virtual async Task<ActionResult<ApiResponse<object>>> Update(int id, [FromBody] TUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ApiResponse<object>.Fail("Datos invalidos."));

        try
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated)
                return NotFound(ApiResponse<object>.Fail($"No se encontro el registro con id {id}."));

            return Ok(ApiResponse<object>.Ok(new { }, "Registro actualizado correctamente."));
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ApiResponse<object>.Fail(ex.Message));
        }
    }

    [HttpDelete("{id:int}")]
    public virtual async Task<ActionResult<ApiResponse<object>>> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted)
            return NotFound(ApiResponse<object>.Fail($"No se encontro el registro con id {id}."));

        return Ok(ApiResponse<object>.Ok(new { }, "Registro eliminado correctamente."));
    }
}
