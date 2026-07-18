using Microsoft.EntityFrameworkCore;
using PatientSystem.Domain.Entities;
using PatientSystem.Domain.Interfaces;

namespace PatientSystem.DataAccess.Repositories;

public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(PatientSystemDbContext context) : base(context) { }

    public async Task<IEnumerable<Appointment>> GetByDateRangeAsync(DateTime from, DateTime to) =>
        await _dbSet.Include(a => a.Patient).Include(a => a.Doctor)
            .Where(a => a.AppointmentDate >= from && a.AppointmentDate <= to)
            .ToListAsync();

    public async Task<IEnumerable<Appointment>> GetByDoctorAsync(int doctorId) =>
        await _dbSet.Include(a => a.Patient)
            .Where(a => a.DoctorId == doctorId)
            .ToListAsync();

    public override async Task<IEnumerable<Appointment>> GetAllAsync() =>
        await _dbSet.Include(a => a.Patient).Include(a => a.Doctor).ToListAsync();

    public override async Task<Appointment?> GetByIdAsync(int id) =>
        await _dbSet.Include(a => a.Patient).Include(a => a.Doctor).FirstOrDefaultAsync(a => a.Id == id);
}
