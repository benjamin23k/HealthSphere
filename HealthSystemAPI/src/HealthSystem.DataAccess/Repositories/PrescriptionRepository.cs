using Microsoft.EntityFrameworkCore;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;

namespace PatientSystem.DataAccess.Repositories;

public class PrescriptionRepository : GenericRepository<Prescription>, IPrescriptionRepository
{
    public PrescriptionRepository(PatientSystemDbContext context) : base(context) { }

    public async Task<IEnumerable<Prescription>> GetByTreatmentIdAsync(int treatmentId) =>
        await _dbSet.Include(p => p.Medication)
            .Where(p => p.TreatmentId == treatmentId)
            .ToListAsync();

    public override async Task<IEnumerable<Prescription>> GetAllAsync() =>
        await _dbSet.Include(p => p.Medication).ToListAsync();

    public override async Task<Prescription?> GetByIdAsync(int id) =>
        await _dbSet.Include(p => p.Medication).FirstOrDefaultAsync(p => p.Id == id);
}
