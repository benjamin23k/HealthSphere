using PatientSystem.DTOs;

namespace PatientSystem.Business.Interfaces;

public interface IPrescriptionService : IBaseCrudService<PrescriptionReadDto, PrescriptionCreateDto, PrescriptionUpdateDto>
{
    Task<IEnumerable<PrescriptionReadDto>> GetByTreatmentIdAsync(int treatmentId);
}
