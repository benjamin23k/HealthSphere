using PatientSystem.Domain.Entities;

namespace PatientSystem.Domain.Interfaces;

public interface IMedicationRepository : IGenericRepository<Medication>
{
    Task<IEnumerable<Medication>> SearchByNameAsync(string name);
}
