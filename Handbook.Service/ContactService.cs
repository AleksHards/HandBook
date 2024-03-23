using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;
using Handbook.Service.ServiceInterfaces;

namespace Handbook.Service;

public class ContactService : IContactService
{
    private readonly IUnitOfWork _unitofWork;

    public ContactService(IUnitOfWork unitofWork)
    {
        _unitofWork = unitofWork;
    }

    public Task<Contact> GetContact(int ContactId)
    {
        Contact Contact = _unitofWork.ContactRepository.Get(ContactId) ?? throw new InvalidDataException("Contact number not found.");
        if (Contact == null)
        {
            throw new InvalidDataException();
        }
        else
        {
            return Task.FromResult(Contact);
        }
    }

    public Task<IQueryable<Contact>> GetAllContacts()
    {
        var Contact = _unitofWork.ContactRepository.Set();
        if (Contact == null)
        {
            throw new InvalidDataException("Contact information not found.");
        }
        else
        {
            return Task.FromResult(Contact);
        }
    }

    public void AddContact(Contact Contact)
    {
        if (Contact == null) throw new ArgumentNullException("No Contact information provided");
        _unitofWork.ContactRepository.Insert(Contact);
        _unitofWork.SaveChanges();
    }

    public void UpdateContact(Contact Contact)
    {
        if (Contact == null) throw new ArgumentNullException("No Contact information provided");
        _unitofWork.ContactRepository.Update(Contact);
        _unitofWork.SaveChanges();
    }

    public void DeleteContact(int ContactId)
    {
        Contact Contact = _unitofWork.ContactRepository.Get(ContactId) ?? throw new InvalidDataException("Contact information not found");
        Contact.IsDeleted = true;
        _unitofWork.ContactRepository.Update(Contact);
        _unitofWork.SaveChanges();
    }
}