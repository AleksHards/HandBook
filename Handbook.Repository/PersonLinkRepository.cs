using Handbook.Service.RepositoryInterfaces;

namespace Handbook.Repository;

public class PersonLinkRepository : RepositoryBase<PersonLinkRepository>, IPersonLinkRepository
{
    internal PersonLinkRepository(HandbookDbContext context) : base(context)
    {

    }
}