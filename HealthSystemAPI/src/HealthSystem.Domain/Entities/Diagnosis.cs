using PatientSystem.Domain.Common;

namespace PatientSystem.Domain.Entities;

public class Diagnosis : BaseEntity
{
    public int MedicalRecordId { get; set; }
    public MedicalRecord? MedicalRecord { get; set; }

    public string Code { get; set; } = string.Empty; 
    public string Description { get; set; } = string.Empty;
    public DateTime DiagnosedDate { get; set; }

    public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}
