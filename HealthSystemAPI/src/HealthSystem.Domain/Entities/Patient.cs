using PatientSystem.Domain.Common;

namespace PatientSystem.Domain.Entities;

public class Patient : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;

    public int? InsuranceId { get; set; }
    public Insurance? Insurance { get; set; }

    public Address? Address { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
}
