using PatientSystem.Domain.Entities;

namespace PatientSystem.Domain.Interfaces;

public interface IAppointmentRepository : IGenericRepository<Appointment>
{
    Task<IEnumerable<Appointment>> GetByDateRangeAsync(DateTime from, DateTime to);
    Task<IEnumerable<Appointment>> GetByDoctorAsync(int doctorId);
}
