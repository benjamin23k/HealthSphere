using Microsoft.EntityFrameworkCore;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;

namespace PatientSystem.DataAccess.Repositories;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(PatientSystemDbContext context) : base(context) { }

    public async Task<Department?> GetByNameAsync(string name) =>
        await _dbSet.FirstOrDefaultAsync(d => d.Name == name);
}
