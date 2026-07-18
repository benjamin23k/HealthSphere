using AutoMapper;
using PatientSystem.Business.Interfaces;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.Business.Services;

public class PatientService : BaseCrudService<Patient, PatientReadDto, PatientCreateDto, PatientUpdateDto>, IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork.Patients, unitOfWork, mapper)
    {
        _patientRepository = unitOfWork.Patients;
    }

    public async Task<PatientReadDto?> GetByDocumentNumberAsync(string documentNumber)
    {
        var patient = await _patientRepository.GetByDocumentNumberAsync(documentNumber);
        return patient is null ? null : _mapper.Map<PatientReadDto>(patient);
    }

    public override async Task<PatientReadDto> CreateAsync(PatientCreateDto dto)
    {
       
        var existing = await _patientRepository.GetByDocumentNumberAsync(dto.DocumentNumber);
        if (existing is not null)
            throw new InvalidOperationException($"There is already a patient with that document. '{dto.DocumentNumber}'.");

        return await base.CreateAsync(dto);
    }
}
