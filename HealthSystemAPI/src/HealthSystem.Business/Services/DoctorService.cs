using AutoMapper;
using PatientSystem.Business.Interfaces;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.Business.Services;

public class DoctorService : BaseCrudService<Doctor, DoctorReadDto, DoctorCreateDto, DoctorUpdateDto>, IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork.Doctors, unitOfWork, mapper)
    {
        _doctorRepository = unitOfWork.Doctors;
    }

    public async Task<IEnumerable<DoctorReadDto>> GetBySpecialtyAsync(string specialty)
    {
        var doctors = await _doctorRepository.GetBySpecialtyAsync(specialty);
        return _mapper.Map<IEnumerable<DoctorReadDto>>(doctors);
    }
}
