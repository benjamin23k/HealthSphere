using Microsoft.EntityFrameworkCore;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;

namespace PatientSystem.DataAccess.Repositories;

public class InsuranceRepository : GenericRepository<Insurance>, IInsuranceRepository
{
    public InsuranceRepository(PatientSystemDbContext context) : base(context) { }

    public async Task<Insurance?> GetByProviderNameAsync(string providerName) =>
        await _dbSet.FirstOrDefaultAsync(i => i.ProviderName == providerName);
}
