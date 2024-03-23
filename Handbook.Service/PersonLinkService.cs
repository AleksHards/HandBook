using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;
using Handbook.Service.ServiceInterfaces;

namespace Handbook.Service;

public class PersonLinkService : IPersonLinkService
{
    private readonly IUnitOfWork _unitofWork;

    public PersonLinkService(IUnitOfWork unitofWork)
    {
        _unitofWork = unitofWork;
    }

    public void AddPersonLink(PersonLink personLink)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<PersonLink>> GetAllPersonLinks()
    {
        var people = _unitofWork.PersonLinkRepository.Set();
        if (people == null)
        {
            throw new InvalidDataException();
        }
        else
        {
            return Task.FromResult(people);
        }
    }

    public void RemovePersonLink(int personLink)
    {
        throw new NotImplementedException();
    }
}