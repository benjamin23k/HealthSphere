using AutoMapper;
using PatientSystem.Business.Interfaces;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.Business.Services;

public class PrescriptionService : BaseCrudService<Prescription, PrescriptionReadDto, PrescriptionCreateDto, PrescriptionUpdateDto>, IPrescriptionService
{
    private readonly IPrescriptionRepository _prescriptionRepository;

    public PrescriptionService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork.Prescriptions, unitOfWork, mapper)
    {
        _prescriptionRepository = unitOfWork.Prescriptions;
    }

    public async Task<IEnumerable<PrescriptionReadDto>> GetByTreatmentIdAsync(int treatmentId)
    {
        var prescriptions = await _prescriptionRepository.GetByTreatmentIdAsync(treatmentId);
        return _mapper.Map<IEnumerable<PrescriptionReadDto>>(prescriptions);
    }
}
