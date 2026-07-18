using PatientSystem.DTOs;

namespace PatientSystem.Business.Interfaces;

public interface IAddressService : IBaseCrudService<AddressReadDto, AddressCreateDto, AddressUpdateDto>
{
    Task<AddressReadDto?> GetByPatientIdAsync(int patientId);
}
