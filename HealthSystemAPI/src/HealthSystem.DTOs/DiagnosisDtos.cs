using System.ComponentModel.DataAnnotations;

namespace PatientSystem.DTOs;

public class DiagnosisReadDto
{
    public int Id { get; set; }
    public int MedicalRecordId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DiagnosedDate { get; set; }
}

public class DiagnosisCreateDto
{
    [Required] public int MedicalRecordId { get; set; }
    [Required, MaxLength(15)] public string Code { get; set; } = string.Empty;
    [Required] public string Description { get; set; } = string.Empty;
    [Required] public DateTime DiagnosedDate { get; set; }
}

public class DiagnosisUpdateDto : DiagnosisCreateDto { }
