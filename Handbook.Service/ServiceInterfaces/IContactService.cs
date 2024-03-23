using Handbook.DTO;

namespace Handbook.Service.ServiceInterfaces;

public interface IContactService
{
    Task<Contact> GetContact(int contact);
    Task<IQueryable<Contact>> GetAllContacts();
    void AddContact(Contact contact);
    void UpdateContact (Contact contact);
    void DeleteContact (int contact);
}