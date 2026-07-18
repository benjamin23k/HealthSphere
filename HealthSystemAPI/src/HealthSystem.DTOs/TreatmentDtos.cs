using System.ComponentModel.DataAnnotations;

namespace PatientSystem.DTOs;

public class TreatmentReadDto
{
    public int Id { get; set; }
    public int DiagnosisId { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class TreatmentCreateDto
{
    [Required] public int DiagnosisId { get; set; }
    [Required] public string Description { get; set; } = string.Empty;
    [Required] public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class TreatmentUpdateDto : TreatmentCreateDto { }
