using System.ComponentModel.DataAnnotations;

namespace PatientSystem.DTOs;

public class MedicalRecordReadDto
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string? PatientFullName { get; set; }
    public int? AppointmentId { get; set; }
    public DateTime VisitDate { get; set; }
    public string? Notes { get; set; }
}

public class MedicalRecordCreateDto
{
    [Required] public int PatientId { get; set; }
    public int? AppointmentId { get; set; }
    [Required] public DateTime VisitDate { get; set; }
    public string? Notes { get; set; }
}

public class MedicalRecordUpdateDto : MedicalRecordCreateDto { }
