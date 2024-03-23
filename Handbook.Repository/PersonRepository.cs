using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;

namespace Handbook.Repository;

internal class PersonRepository: RepositoryBase<Person>, IPersonRepository
{
    internal PersonRepository(HandbookDbContext context) : base(context)
    {

    }
}