namespace PatientSystem.Business.Interfaces;


public interface IBaseCrudService<TReadDto, in TCreateDto, in TUpdateDto>
    where TReadDto : class
{
    Task<IEnumerable<TReadDto>> GetAllAsync();
    Task<TReadDto?> GetByIdAsync(int id);
    Task<TReadDto> CreateAsync(TCreateDto dto);
    Task<bool> UpdateAsync(int id, TUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
