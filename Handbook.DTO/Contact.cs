namespace Handbook.DTO;

public class Contact
{
    public string Id { get; set; } = null!;
    public string ContactInformation { get; set; } = null!;
    public ContactType Type { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDeleted { get; set; }
    public Person? Person { get; set; }
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