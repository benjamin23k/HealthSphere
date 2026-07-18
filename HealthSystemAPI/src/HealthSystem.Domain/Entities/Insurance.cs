using PatientSystem.Domain.Common;

namespace PatientSystem.Domain.Entities;

public class Insurance : BaseEntity
{
    public string ProviderName { get; set; } = string.Empty;
    public string? PolicyPrefix { get; set; }
    public decimal CoveragePercentage { get; set; }
    public string? ContactPhone { get; set; }

    public ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
