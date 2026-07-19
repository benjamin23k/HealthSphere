using PatientSystem.Domain.Entities;

namespace PatientSystem.Domain.Interfaces;

public interface IPrescriptionRepository : IGenericRepository<Prescription>
{
    Task<IEnumerable<Prescription>> GetByTreatmentIdAsync(int treatmentId);
}
