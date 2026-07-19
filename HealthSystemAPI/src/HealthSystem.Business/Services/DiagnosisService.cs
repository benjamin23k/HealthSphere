using AutoMapper;
using PatientSystem.Business.Interfaces;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.Business.Services;

public class DiagnosisService : BaseCrudService<Diagnosis, DiagnosisReadDto, DiagnosisCreateDto, DiagnosisUpdateDto>, IDiagnosisService
{
    private readonly IDiagnosisRepository _diagnosisRepository;

    public DiagnosisService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork.Diagnoses, unitOfWork, mapper)
    {
        _diagnosisRepository = unitOfWork.Diagnoses;
    }

    public async Task<IEnumerable<DiagnosisReadDto>> GetByMedicalRecordIdAsync(int medicalRecordId)
    {
        var diagnoses = await _diagnosisRepository.GetByMedicalRecordIdAsync(medicalRecordId);
        return _mapper.Map<IEnumerable<DiagnosisReadDto>>(diagnoses);
    }
}
