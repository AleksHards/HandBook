using Handbook.DTO;
using Microsoft.EntityFrameworkCore;

namespace Handbook.Repository;

public class HandbookDbContext : DbContext
{
    public HandbookDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<PersonLink> PersonLinks { get; set; }
}
