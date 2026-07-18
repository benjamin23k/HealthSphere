using PatientSystem.Domain.Common;

namespace PatientSystem.Domain.Entities;

public class Treatment : BaseEntity
{
    public int DiagnosisId { get; set; }
    public Diagnosis? Diagnosis { get; set; }

    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
