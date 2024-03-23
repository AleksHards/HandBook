using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;
using Handbook.Service.ServiceInterfaces;

namespace Handbook.Service;

public class PersonService : IPersonService
{
    private readonly IUnitOfWork _unitofWork;

    public PersonService(IUnitOfWork unitofWork)
    {
        _unitofWork = unitofWork;
    }

    public Task<Person> GetPerson(int PersonId)
    {
        Person person = _unitofWork.PersonRepository.Get(PersonId) ?? throw new InvalidDataException("Person number not found.");
        if (person == null)
        {
            throw new InvalidDataException();
        }
        else
        {
            return Task.FromResult(person);
        }
    }

    public Task<IQueryable<Person>> GetAllPersons()
    {
        var people = _unitofWork.PersonRepository.Set();
        if (people == null)
        {
            throw new InvalidDataException();
        }
        else
        {
            return Task.FromResult(people);
        }
    }

    public void AddPerson(Person Person)
    {
        if (Person == null) throw new ArgumentNullException("No Person provided");
        _unitofWork.PersonRepository.Insert(Person);
        _unitofWork.SaveChanges();
    }

    public void UpdatePerson(Person Person)
    {
        if (Person == null) throw new ArgumentNullException("No Person provided");
        _unitofWork.PersonRepository.Update(Person);
        _unitofWork.SaveChanges();
    }

    public void DeletePerson(int PersonId)
    {
        Person Person = _unitofWork.PersonRepository.Get(PersonId) ?? throw new InvalidDataException("Person not found");
        Person.IsDeleted = true;
        _unitofWork.PersonRepository.Update(Person);
        _unitofWork.SaveChanges();
    }
}