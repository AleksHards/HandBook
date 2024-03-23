using System.ComponentModel.DataAnnotations;

namespace Handbook.DTO;

public class Phone
{
    [Key, Required]
    public string Id { get; set; } = null!;

    [Required, MaxLength(50)]
    public string ContactInformation { get; set; } = null!;
    public ContactType Type { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDeleted { get; set; }

    public Phone()
    {
        this.CreateDate = DateTime.Now;
        this.IsDeleted = false;
    }
}

public enum ContactType
{
    MobilePhone = 0,
    OfficePhone = 1,
    HomePhone = 2,
    Email = 3,
    WorkAddress = 4,
    HomeAddress = 5,
    Other = 6,
}