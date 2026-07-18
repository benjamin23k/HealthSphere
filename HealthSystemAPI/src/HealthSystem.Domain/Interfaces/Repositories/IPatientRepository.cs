using PatientSystem.Domain.Entities;

namespace PatientSystem.Domain.Interfaces;

public interface IPatientRepository : IGenericRepository<Patient>
{
    Task<Patient?> GetByDocumentNumberAsync(string documentNumber);
    Task<Patient?> GetWithFullHistoryAsync(int patientId);
}
