using System.ComponentModel.DataAnnotations;

namespace PatientSystem.DTOs;

public class AddressReadDto
{
    public int Id { get; set; }
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string Country { get; set; } = string.Empty;
    public int PatientId { get; set; }
}

public class AddressCreateDto
{
    [Required] public string Street { get; set; } = string.Empty;
    [Required] public string City { get; set; } = string.Empty;
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    [Required] public string Country { get; set; } = string.Empty;
    [Required] public int PatientId { get; set; }
}

public class AddressUpdateDto : AddressCreateDto { }
