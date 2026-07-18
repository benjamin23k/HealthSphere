using Microsoft.EntityFrameworkCore;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;

namespace PatientSystem.DataAccess.Repositories;

public class TreatmentRepository : GenericRepository<Treatment>, ITreatmentRepository
{
    public TreatmentRepository(PatientSystemDbContext context) : base(context) { }

    public async Task<IEnumerable<Treatment>> GetByDiagnosisIdAsync(int diagnosisId) =>
        await _dbSet.Where(t => t.DiagnosisId == diagnosisId).ToListAsync();
}
