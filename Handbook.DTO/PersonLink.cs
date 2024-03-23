using System.ComponentModel.DataAnnotations;

namespace Handbook.DTO;

public class PersonLink
{
    [Key, Required]
    public int id { get; set; }

    [Required]
    public Person person { get; set; } = null!;

    [Required]
    public Person relative { get; set; } = null!;

    public RelationType type { get; set; }
}

public enum RelationType
{
    Colleague = 0,
    Acquaintance = 1,
    Relative = 2,
    Other = 3,
}