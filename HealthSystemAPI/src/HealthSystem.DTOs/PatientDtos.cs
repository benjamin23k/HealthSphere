using System.ComponentModel.DataAnnotations;

namespace PatientSystem.DTOs;

public class PatientReadDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public int? InsuranceId { get; set; }
    public string? InsuranceProviderName { get; set; }
}

public class PatientCreateDto
{
    [Required, MaxLength(80)]
    public string FirstName { get; set; } = string.Empty;
    [Required, MaxLength(80)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required, MaxLength(20)]
    public string Gender { get; set; } = string.Empty;
    [EmailAddress]
    public string? Email { get; set; }
    public string? Phone { get; set; }
    [Required, MaxLength(30)]
    public string DocumentNumber { get; set; } = string.Empty;
    public int? InsuranceId { get; set; }
}

public class PatientUpdateDto : PatientCreateDto { }
