using AutoMapper;
using PatientSystem.Business.Interfaces;
using PatientSystem.Domain.Common;
using PatientSystem.Domain.Interfaces;

namespace PatientSystem.Business.Services;


public class BaseCrudService<TEntity, TReadDto, TCreateDto, TUpdateDto>
    : IBaseCrudService<TReadDto, TCreateDto, TUpdateDto>
    where TEntity : BaseEntity
    where TReadDto : class
{
    protected readonly IGenericRepository<TEntity> _repository;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    public BaseCrudService(IGenericRepository<TEntity> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public virtual async Task<IEnumerable<TReadDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TReadDto>>(entities);
    }

    public virtual async Task<TReadDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : _mapper.Map<TReadDto>(entity);
    }

    public virtual async Task<TReadDto> CreateAsync(TCreateDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TReadDto>(entity);
    }

    public virtual async Task<bool> UpdateAsync(int id, TUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;

        _mapper.Map(dto, entity);
        _repository.Update(entity);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;

        
        entity.IsActive = false;
        _repository.Update(entity);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
