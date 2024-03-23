using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;
using Handbook.Service.ServiceInterfaces;

namespace Handbook.Service;

public class PhoneService : IPhoneService
{
    private readonly IUnitOfWork _unitofWork;

    public PhoneService(IUnitOfWork unitofWork)
    {
        _unitofWork = unitofWork;
    }

    public Task<Phone> GetPhone(int PhoneId)
    {
        Phone phone = _unitofWork.PhoneRepository.Get(PhoneId) ?? throw new InvalidDataException("Phone number not found.");
        if (phone == null)
        {
            throw new InvalidDataException();
        }
        else
        {
            return Task.FromResult(phone);
        }
    }

    public Task<IQueryable<Phone>> GetAllPhones()
    {
        var phone = _unitofWork.PhoneRepository.Set();
        if (phone == null)
        {
            throw new InvalidDataException("Phone numbers not found.");
        }
        else
        {
            return Task.FromResult(phone);
        }
    }

    public void AddPhone(Phone Phone)
    {
        if (Phone == null) throw new ArgumentNullException("No Phone number provided");
        _unitofWork.PhoneRepository.Insert(Phone);
        _unitofWork.SaveChanges();
    }

    public void UpdatePhone(Phone Phone)
    {
        if (Phone == null) throw new ArgumentNullException("No Phone number provided");
        _unitofWork.PhoneRepository.Update(Phone);
        _unitofWork.SaveChanges();
    }

    public void DeletePhone(int PhoneId)
    {
        Phone Phone = _unitofWork.PhoneRepository.Get(PhoneId) ?? throw new InvalidDataException("Phone number not found");
        Phone.IsDeleted = true;
        _unitofWork.PhoneRepository.Update(Phone);
        _unitofWork.SaveChanges();
    }
}