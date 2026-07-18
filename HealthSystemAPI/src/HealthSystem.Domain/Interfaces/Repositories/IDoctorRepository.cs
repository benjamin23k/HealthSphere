using PatientSystem.Domain.Entities;

namespace PatientSystem.Domain.Interfaces;

public interface IDoctorRepository : IGenericRepository<Doctor>
{
    Task<IEnumerable<Doctor>> GetBySpecialtyAsync(string specialty);
}
