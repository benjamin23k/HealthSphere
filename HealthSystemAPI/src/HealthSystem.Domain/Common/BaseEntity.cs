namespace PatientSystem.Domain.Common;

/// <summary>
/// Clase base para todas las entidades del dominio.
/// Aplica el principio DRY: los campos comunes de auditoria/estado
/// viven en un solo lugar en lugar de repetirse en cada tabla.
/// </summary>
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true; // borrado logico (soft delete)
}
