namespace Handbook.DTO;

public class City
{
    public int Id { get; set; }
    public string CityName { get; set; } = null!;
    public string CityCode { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<Person>? Persons { get; set; }
}