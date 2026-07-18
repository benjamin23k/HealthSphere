using Microsoft.EntityFrameworkCore;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;

namespace PatientSystem.DataAccess.Repositories;

public class MedicalRecordRepository : GenericRepository<MedicalRecord>, IMedicalRecordRepository
{
    public MedicalRecordRepository(PatientSystemDbContext context) : base(context) { }

    public async Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId) =>
        await _dbSet.Include(m => m.Patient)
            .Where(m => m.PatientId == patientId)
            .ToListAsync();

    public override async Task<IEnumerable<MedicalRecord>> GetAllAsync() =>
        await _dbSet.Include(m => m.Patient).ToListAsync();

    public override async Task<MedicalRecord?> GetByIdAsync(int id) =>
        await _dbSet.Include(m => m.Patient).FirstOrDefaultAsync(m => m.Id == id);
}
