using AutoMapper;
using PatientSystem.Business.Interfaces;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.Business.Services;

public class AddressService : BaseCrudService<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>, IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork.Addresses, unitOfWork, mapper)
    {
        _addressRepository = unitOfWork.Addresses;
    }

    public async Task<AddressReadDto?> GetByPatientIdAsync(int patientId)
    {
        var address = await _addressRepository.GetByPatientIdAsync(patientId);
        return address is null ? null : _mapper.Map<AddressReadDto>(address);
    }
}
