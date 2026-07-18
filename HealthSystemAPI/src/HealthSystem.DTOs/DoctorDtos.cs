using System.ComponentModel.DataAnnotations;

namespace PatientSystem.DTOs;

public class DoctorReadDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
}

public class DoctorCreateDto
{
    [Required, MaxLength(80)]
    public string FirstName { get; set; } = string.Empty;
    [Required, MaxLength(80)]
    public string LastName { get; set; } = string.Empty;
    [Required, MaxLength(100)]
    public string Specialty { get; set; } = string.Empty;
    [Required, MaxLength(30)]
    public string LicenseNumber { get; set; } = string.Empty;
    [EmailAddress]
    public string? Email { get; set; }
    public string? Phone { get; set; }
    [Required]
    public int DepartmentId { get; set; }
}

public class DoctorUpdateDto : DoctorCreateDto { }
