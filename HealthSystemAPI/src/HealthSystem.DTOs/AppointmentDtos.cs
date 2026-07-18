using System.ComponentModel.DataAnnotations;
using PatientSystem.Domain.Entities;

namespace PatientSystem.DTOs;

public class AppointmentReadDto
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string? PatientFullName { get; set; }
    public int DoctorId { get; set; }
    public string? DoctorFullName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string? Reason { get; set; }
    public AppointmentStatus Status { get; set; }
}

public class AppointmentCreateDto
{
    [Required] public int PatientId { get; set; }
    [Required] public int DoctorId { get; set; }
    [Required] public DateTime AppointmentDate { get; set; }
    public string? Reason { get; set; }
}

public class AppointmentUpdateDto : AppointmentCreateDto
{
    public AppointmentStatus Status { get; set; }
}
