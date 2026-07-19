using PatientSystem.DTOs;

namespace PatientSystem.Business.Interfaces;

public interface IInsuranceService : IBaseCrudService<InsuranceReadDto, InsuranceCreateDto, InsuranceUpdateDto>
{
    Task<InsuranceReadDto?> GetByProviderNameAsync(string providerName);
}
