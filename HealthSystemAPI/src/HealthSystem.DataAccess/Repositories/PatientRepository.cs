using Microsoft.EntityFrameworkCore;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;

namespace PatientSystem.DataAccess.Repositories;

public class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    public PatientRepository(PatientSystemDbContext context) : base(context) { }

    public async Task<Patient?> GetByDocumentNumberAsync(string documentNumber) =>
        await _dbSet.FirstOrDefaultAsync(p => p.DocumentNumber == documentNumber);

    public async Task<Patient?> GetWithFullHistoryAsync(int patientId) =>
        await _dbSet
            .Include(p => p.Address)
            .Include(p => p.Insurance)
            .Include(p => p.MedicalRecords).ThenInclude(m => m.Diagnoses).ThenInclude(d => d.Treatments)
            .FirstOrDefaultAsync(p => p.Id == patientId);
}
