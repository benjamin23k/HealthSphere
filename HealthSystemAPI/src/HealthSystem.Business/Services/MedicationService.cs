using AutoMapper;
using PatientSystem.Business.Interfaces;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.Business.Services;

public class MedicationService : BaseCrudService<Medication, MedicationReadDto, MedicationCreateDto, MedicationUpdateDto>, IMedicationService
{
    private readonly IMedicationRepository _medicationRepository;

    public MedicationService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork.Medications, unitOfWork, mapper)
    {
        _medicationRepository = unitOfWork.Medications;
    }

    public async Task<IEnumerable<MedicationReadDto>> SearchByNameAsync(string name)
    {
        var medications = await _medicationRepository.SearchByNameAsync(name);
        return _mapper.Map<IEnumerable<MedicationReadDto>>(medications);
    }
}
