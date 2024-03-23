using Handbook.DTO;

namespace Handbook.Service.ServiceInterfaces;

public interface IPersonLinkService
{
    Task<IQueryable<PersonLink>> GetAllPersonLinks();
    void AddPersonLink(PersonLink personLink);
    void RemovePersonLink(int personLink);
}