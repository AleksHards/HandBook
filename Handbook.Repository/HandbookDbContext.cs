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

        modelBuilder.Entity<City>().Property(c => c.CityName).HasColumnType("nvarchar(30)").IsRequired();
        modelBuilder.Entity<City>().HasIndex(c => c.CityName).IsUnique(true);
        modelBuilder.Entity<City>().Property(c => c.CreateDate).HasColumnType("date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<City>().Property(c => c.IsDeleted).HasColumnType("bit").HasDefaultValueSql("(0)");
        modelBuilder.Entity<City>().HasMany(c => c.Persons).WithOne(c => c.City).IsRequired(false);

        modelBuilder.Entity<Person>().Property(p => p.FirstName).HasColumnType("nvarchar(30)").IsRequired();
        modelBuilder.Entity<Person>().Property(p => p.LastName).HasColumnType("nvarchar(30)").IsRequired();
        modelBuilder.Entity<Person>().Property(p => p.IdNumber).HasColumnType("nvarchar(15)").IsRequired();
        modelBuilder.Entity<Person>().Property(p => p.DateOfBirth).HasColumnType("date").IsRequired();
        modelBuilder.Entity<Person>().Property(p => p.CreateDate).HasColumnType("date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<Person>().Property(p => p.IsDeleted).HasColumnType("bit").HasDefaultValueSql("(0)");
        modelBuilder.Entity<Person>().HasOne(ct => ct.City).WithMany(p => p.Persons).IsRequired(false);
        modelBuilder.Entity<Person>().HasMany(c => c.Contacts).WithOne(p => p.Person).IsRequired(false);
        modelBuilder.Entity<Person>().HasMany(pl => pl.PersonLink).WithOne(p => p.PersonFrom).IsRequired(false);
        modelBuilder.Entity<Person>().HasMany(pl => pl.PersonLink).WithOne(p => p.PersonTo).IsRequired(false);

        modelBuilder.Entity<Contact>().Property(c => c.ContactInformation).HasColumnType("nvarchar(30)").IsRequired();
        modelBuilder.Entity<Person>().Property(c => c.CreateDate).HasColumnType("date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<Person>().Property(c => c.IsDeleted).HasColumnType("bit").HasDefaultValueSql("(0)");
        modelBuilder.Entity<Contact>().HasOne(p => p.Person).WithMany(c => c.Contacts).IsRequired(false);

        modelBuilder.Entity<PersonLink>().HasOne(p => p.PersonFrom).WithMany(pl => pl.PersonLink).IsRequired(false);
        modelBuilder.Entity<PersonLink>().HasOne(p => p.PersonTo).WithMany(pl => pl.PersonLink).IsRequired(false);
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Contact> Phones { get; set; }
    public DbSet<PersonLink> PersonLinks { get; set; }
}
