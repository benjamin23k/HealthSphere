using PatientSystem.Domain.Common;

namespace PatientSystem.Domain.Entities;


public class Address : BaseEntity
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string Country { get; set; } = string.Empty;

    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
}
