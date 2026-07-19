using PatientSystem.Domain.Entities;

namespace PatientSystem.Domain.Interfaces;

public interface IAddressRepository : IGenericRepository<Address>
{
    Task<Address?> GetByPatientIdAsync(int patientId);
}
