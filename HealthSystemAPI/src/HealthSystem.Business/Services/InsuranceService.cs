using AutoMapper;
using PatientSystem.Business.Interfaces;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.Business.Services;

public class InsuranceService : BaseCrudService<Insurance, InsuranceReadDto, InsuranceCreateDto, InsuranceUpdateDto>, IInsuranceService
{
    private readonly IInsuranceRepository _insuranceRepository;

    public InsuranceService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork.Insurances, unitOfWork, mapper)
    {
        _insuranceRepository = unitOfWork.Insurances;
    }

    public async Task<InsuranceReadDto?> GetByProviderNameAsync(string providerName)
    {
        var insurance = await _insuranceRepository.GetByProviderNameAsync(providerName);
        return insurance is null ? null : _mapper.Map<InsuranceReadDto>(insurance);
    }
}
