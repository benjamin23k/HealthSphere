using System.ComponentModel.DataAnnotations;

namespace PatientSystem.DTOs;

public class PrescriptionReadDto
{
    public int Id { get; set; }
    public int TreatmentId { get; set; }
    public int MedicationId { get; set; }
    public string? MedicationName { get; set; }
    public string Dosage { get; set; } = string.Empty;
    public string Frequency { get; set; } = string.Empty;
    public int DurationDays { get; set; }
}

public class PrescriptionCreateDto
{
    [Required] public int TreatmentId { get; set; }
    [Required] public int MedicationId { get; set; }
    [Required] public string Dosage { get; set; } = string.Empty;
    [Required] public string Frequency { get; set; } = string.Empty;
    [Range(1, 365)] public int DurationDays { get; set; }
}

public class PrescriptionUpdateDto : PrescriptionCreateDto { }
