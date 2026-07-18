using PatientSystem.Domain.Common;

namespace PatientSystem.Domain.Entities;

public class MedicalRecord : BaseEntity
{
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }

    public int? AppointmentId { get; set; }
    public Appointment? Appointment { get; set; }

    public DateTime VisitDate { get; set; }
    public string? Notes { get; set; }

    public ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();
}
