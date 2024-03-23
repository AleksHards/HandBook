using Handbook.DTO;

namespace Handbook.Service.ServiceInterfaces;

public interface IPersonService
{
    Task<Person> GetPerson(int person);
    Task<IQueryable<Person>> GetAllPersons();
    void AddPerson (Person person);
    void UpdatePerson(Person person);
    void DeletePerson (int person);
}
