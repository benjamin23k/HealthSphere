using PatientSystem.Domain.Entities;

namespace PatientSystem.Domain.Interfaces;

public interface IDepartmentRepository : IGenericRepository<Department>
{
    Task<Department?> GetByNameAsync(string name);
}
