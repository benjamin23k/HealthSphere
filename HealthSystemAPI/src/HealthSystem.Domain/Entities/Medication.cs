using PatientSystem.Domain.Common;

namespace PatientSystem.Domain.Entities;

public class Medication : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Manufacturer { get; set; }
    public string? Form { get; set; } 
    public string? Concentration { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
