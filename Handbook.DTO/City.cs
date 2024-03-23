using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Handbook.DTO;

public class City
{
    [Key, Required]
    public int Id { get; set; } = null!;

    [Required, MaxLength(30)]
    public string CityName { get; set; } = null!;

    [MaxLength(10)]
    public string CityCode { get; set; } = null!;

    public DateTime CreateDate { get; set; }
    public bool IsDeleted { get; set; }

    public City()
    {
        this.CreateDate= DateTime.Now;
        this.IsDeleted= false;
    }
}