using Microsoft.EntityFrameworkCore;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;

namespace PatientSystem.DataAccess.Repositories;

public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    public AddressRepository(PatientSystemDbContext context) : base(context) { }

    public async Task<Address?> GetByPatientIdAsync(int patientId) =>
        await _dbSet.FirstOrDefaultAsync(a => a.PatientId == patientId);
}
