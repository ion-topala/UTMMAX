namespace UTMMAX.Domain.Entities;

public class BaseEntity
{
    public int      Id           { get; set; }
    public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedOnUtc { get; set; } = DateTime.UtcNow;
}