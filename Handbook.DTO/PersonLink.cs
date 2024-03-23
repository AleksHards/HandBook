using System.ComponentModel.DataAnnotations;

namespace Handbook.DTO;

public class PersonLink
{
    public int Id { get; set; }
    public Person Person { get; set; } = null!;
    public Person Relative { get; set; } = null!;
    public RelationType Type { get; set; }
}

public enum RelationType
{
    Colleague = 0,
    Acquaintance = 1,
    Relative = 2,
    Other = 3,
}