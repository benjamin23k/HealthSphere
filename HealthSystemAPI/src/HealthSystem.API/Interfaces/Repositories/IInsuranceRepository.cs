using PatientSystem.Domain.Entities;

namespace PatientSystem.Domain.Interfaces;

public interface IInsuranceRepository : IGenericRepository<Insurance>
{
    Task<Insurance?> GetByProviderNameAsync(string providerName);
}
