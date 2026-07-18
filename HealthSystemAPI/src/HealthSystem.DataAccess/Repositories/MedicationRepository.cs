using Microsoft.EntityFrameworkCore;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;

namespace PatientSystem.DataAccess.Repositories;

public class MedicationRepository : GenericRepository<Medication>, IMedicationRepository
{
    public MedicationRepository(PatientSystemDbContext context) : base(context) { }

    public async Task<IEnumerable<Medication>> SearchByNameAsync(string name) =>
        await _dbSet.Where(m => m.Name.Contains(name)).ToListAsync();
}
