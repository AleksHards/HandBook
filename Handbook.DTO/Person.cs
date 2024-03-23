using System.ComponentModel.DataAnnotations;

namespace Handbook.DTO;

public class Person
{
    public int Id {  get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string IdNumber { get; set; } = null!;
    public enum Gender { Male = 0, Female = 1 }
    public DateTime DateOfBirth { get; set; }
    public City? City { get; set; }
    public ICollection<Contact>? Contacts { get; set; }
    public ICollection<PersonLink>? PersonLink { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDeleted { get; set; }
}