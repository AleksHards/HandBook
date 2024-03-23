using System.ComponentModel.DataAnnotations;

namespace Handbook.DTO;

public class Phone
{
    [Key, Required]
    public string Id { get; set; } = null!;

    [Required, MaxLength(15)]
    public string PhoneNumber { get; set; } = null!;
    public PhoneType Type { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDeleted { get; set; }

    public Phone()
    {
        this.CreateDate = DateTime.Now;
        this.IsDeleted = false;
    }
}

public enum PhoneType
{
    Mobile = 0,
    Office = 1,
    Home = 2,
}