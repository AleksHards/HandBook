using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;

namespace Handbook.Repository;

public class PhoneRepository: RepositoryBase<PersonRepository>, IPhoneRepository
{
    internal PhoneRepository(HandbookDbContext context) : base(context)
    {

    }
}