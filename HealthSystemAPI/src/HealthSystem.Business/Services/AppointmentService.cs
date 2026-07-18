using AutoMapper;
using PatientSystem.Business.Interfaces;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;
using PatientSystem.DTOs;

namespace PatientSystem.Business.Services;

public class AppointmentService : BaseCrudService<Appointment, AppointmentReadDto, AppointmentCreateDto, AppointmentUpdateDto>, IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork.Appointments, unitOfWork, mapper)
    {
        _appointmentRepository = unitOfWork.Appointments;
    }

    public async Task<IEnumerable<AppointmentReadDto>> GetByDateRangeAsync(DateTime from, DateTime to)
    {
        var appointments = await _appointmentRepository.GetByDateRangeAsync(from, to);
        return _mapper.Map<IEnumerable<AppointmentReadDto>>(appointments);
    }

    public override async Task<AppointmentReadDto> CreateAsync(AppointmentCreateDto dto)
    {
        
        var doctorAppointments = await _appointmentRepository.GetByDoctorAsync(dto.DoctorId);
        if (doctorAppointments.Any(a => a.AppointmentDate == dto.AppointmentDate))
            throw new InvalidOperationException("The doctor already has an appointment scheduled at that time.");

        return await base.CreateAsync(dto);
    }
}
