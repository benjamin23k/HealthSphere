using System.ComponentModel.DataAnnotations;

namespace PatientSystem.DTOs;

public class InsuranceReadDto
{
    public int Id { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public string? PolicyPrefix { get; set; }
    public decimal CoveragePercentage { get; set; }
    public string? ContactPhone { get; set; }
}

public class InsuranceCreateDto
{
    [Required, MaxLength(100)]
    public string ProviderName { get; set; } = string.Empty;
    public string? PolicyPrefix { get; set; }

    [Range(0, 100)]
    public decimal CoveragePercentage { get; set; }
    public string? ContactPhone { get; set; }
}

public class InsuranceUpdateDto : InsuranceCreateDto { }
