using PatientSystem.DTOs;

namespace PatientSystem.Business.Interfaces;

public interface IAppointmentService : IBaseCrudService<AppointmentReadDto, AppointmentCreateDto, AppointmentUpdateDto>
{
    Task<IEnumerable<AppointmentReadDto>> GetByDateRangeAsync(DateTime from, DateTime to);
}
