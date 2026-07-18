using PatientSystem.Domain.Common;

namespace PatientSystem.Domain.Entities;

public class Appointment : BaseEntity
{
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }

    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }

    public DateTime AppointmentDate { get; set; }
    public string? Reason { get; set; }
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

    public MedicalRecord? MedicalRecord { get; set; }
}
