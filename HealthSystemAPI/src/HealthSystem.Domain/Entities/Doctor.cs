using PatientSystem.Domain.Common;

namespace PatientSystem.Domain.Entities;

public class Doctor : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
