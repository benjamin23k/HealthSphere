using System.ComponentModel.DataAnnotations;

namespace PatientSystem.DTOs;

public class DepartmentReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Location { get; set; }
}

public class DepartmentCreateDto
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Location { get; set; }
}

public class DepartmentUpdateDto : DepartmentCreateDto { }
