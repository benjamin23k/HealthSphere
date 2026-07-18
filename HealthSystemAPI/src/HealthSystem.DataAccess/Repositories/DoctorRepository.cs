using Microsoft.EntityFrameworkCore;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;

namespace PatientSystem.DataAccess.Repositories;

public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(PatientSystemDbContext context) : base(context) { }

    public async Task<IEnumerable<Doctor>> GetBySpecialtyAsync(string specialty) =>
        await _dbSet.Where(d => d.Specialty.Contains(specialty)).ToListAsync();

    public override async Task<IEnumerable<Doctor>> GetAllAsync() =>
        await _dbSet.Include(d => d.Department).ToListAsync();

    public override async Task<Doctor?> GetByIdAsync(int id) =>
        await _dbSet.Include(d => d.Department).FirstOrDefaultAsync(d => d.Id == id);
}
