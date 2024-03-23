using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;

namespace Handbook.Repository;

public class PersonLinkRepository : RepositoryBase<PersonLink>, IPersonLinkRepository
{
    internal PersonLinkRepository(HandbookDbContext context) : base(context)
    {

    }
}