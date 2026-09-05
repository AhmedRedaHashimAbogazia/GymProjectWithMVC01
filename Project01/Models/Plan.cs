using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject1.Models;

public class Plan
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int DurationDays { get; set; }
    public bool IsActive { get; set; }

    [NotMapped]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [NotMapped]
    public DateTime? UpdatedAt { get; set; }
}
