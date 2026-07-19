using AutoMapper;
using PatientSystem.Business.Interfaces;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.Business.Services;

public class MedicalRecordService : BaseCrudService<MedicalRecord, MedicalRecordReadDto, MedicalRecordCreateDto, MedicalRecordUpdateDto>, IMedicalRecordService
{
    private readonly IMedicalRecordRepository _medicalRecordRepository;

    public MedicalRecordService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork.MedicalRecords, unitOfWork, mapper)
    {
        _medicalRecordRepository = unitOfWork.MedicalRecords;
    }

    public async Task<IEnumerable<MedicalRecordReadDto>> GetByPatientIdAsync(int patientId)
    {
        var records = await _medicalRecordRepository.GetByPatientIdAsync(patientId);
        return _mapper.Map<IEnumerable<MedicalRecordReadDto>>(records);
    }
}
