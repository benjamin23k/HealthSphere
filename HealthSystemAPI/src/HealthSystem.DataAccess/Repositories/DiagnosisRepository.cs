using Microsoft.EntityFrameworkCore;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;

namespace PatientSystem.DataAccess.Repositories;

public class DiagnosisRepository : GenericRepository<Diagnosis>, IDiagnosisRepository
{
    public DiagnosisRepository(PatientSystemDbContext context) : base(context) { }

    public async Task<IEnumerable<Diagnosis>> GetByMedicalRecordIdAsync(int medicalRecordId) =>
        await _dbSet.Where(d => d.MedicalRecordId == medicalRecordId).ToListAsync();
}
