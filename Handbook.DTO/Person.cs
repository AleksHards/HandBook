using System.ComponentModel.DataAnnotations;

namespace Handbook.DTO;

public class Person
{
    [Key, Required]
    public int Id {  get; set; } = null!;

    [Required, MaxLength(30)]
    public string FirstName { get; set; } = null!;

    [Required, MaxLength(30)]
    public string LastName { get; set; } = null!;

    [Required, MaxLength(15)] //წესით 11 უნდა იყოს მაგრამ მაინც...
    public string IdNumber { get; set; } = null!;

    public enum Gender { Male = 0, Female = 1 }
    public DateTime DateOfBirth { get; set; }
    public City? City { get; set; }
    public ICollection<Phone>? Phone { get; set; }
    public ICollection<Person>? PersonLink { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDeleted { get; set; }

    public Person()
    {
        this.CreateDate = DateTime.Now;
        this.IsDeleted = false;
    }
}