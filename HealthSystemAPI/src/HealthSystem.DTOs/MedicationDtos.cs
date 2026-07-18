using System.ComponentModel.DataAnnotations;

namespace PatientSystem.DTOs;

public class MedicationReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Manufacturer { get; set; }
    public string? Form { get; set; }
    public string? Concentration { get; set; }
}

public class MedicationCreateDto
{
    [Required, MaxLength(120)] public string Name { get; set; } = string.Empty;
    public string? Manufacturer { get; set; }
    public string? Form { get; set; }
    public string? Concentration { get; set; }
}

public class MedicationUpdateDto : MedicationCreateDto { }
