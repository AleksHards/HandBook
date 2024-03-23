using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;

namespace Handbook.Repository;

internal class PersonLinkRepository : RepositoryBase<PersonLink>, IPersonLinkRepository
{
    internal PersonLinkRepository(HandbookDbContext context) : base(context)
    {

    }
}