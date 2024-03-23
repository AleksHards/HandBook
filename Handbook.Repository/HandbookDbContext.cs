using Handbook.DTO;
using Microsoft.EntityFrameworkCore;

namespace Handbook.Repository;

public class HandbookDbContext : DbContext
{
    public HandbookDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        model
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<PersonLink> PersonLinks { get; set; }
}
