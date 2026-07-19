using AutoMapper;
using PatientSystem.Business.Interfaces;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.Business.Services;

public class TreatmentService : BaseCrudService<Treatment, TreatmentReadDto, TreatmentCreateDto, TreatmentUpdateDto>, ITreatmentService
{
    private readonly ITreatmentRepository _treatmentRepository;

    public TreatmentService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork.Treatments, unitOfWork, mapper)
    {
        _treatmentRepository = unitOfWork.Treatments;
    }

    public async Task<IEnumerable<TreatmentReadDto>> GetByDiagnosisIdAsync(int diagnosisId)
    {
        var treatments = await _treatmentRepository.GetByDiagnosisIdAsync(diagnosisId);
        return _mapper.Map<IEnumerable<TreatmentReadDto>>(treatments);
    }
}
