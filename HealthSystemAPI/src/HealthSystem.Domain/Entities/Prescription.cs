using PatientSystem.Domain.Common;

namespace PatientSystem.Domain.Entities;


public class Prescription : BaseEntity
{
    public int TreatmentId { get; set; }
    public Treatment? Treatment { get; set; }

    public int MedicationId { get; set; }
    public Medication? Medication { get; set; }

    public string Dosage { get; set; } = string.Empty;
    public string Frequency { get; set; } = string.Empty;
    public int DurationDays { get; set; }
}
