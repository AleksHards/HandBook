using Handbook.DTO;

namespace Handbook.Service.ServiceInterfaces;

public interface IPhoneService
{
    Task<Phone> GetPhone(int phone);
    Task<IQueryable<Phone>> GetAllPhones();
    void AddPhone (Phone phone);
    void UpdatePhone (Phone phone);
    void DeletePhone (int phone);
}