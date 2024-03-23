using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;

namespace Handbook.Repository;

internal class ContactRepository: RepositoryBase<Contact>, IContactRepository
{
    internal ContactRepository(HandbookDbContext context) : base(context)
    {

    }
}