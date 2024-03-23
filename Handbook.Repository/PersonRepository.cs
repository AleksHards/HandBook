using Handbook.Service.RepositoryInterfaces;

namespace Handbook.Repository;

public class PersonRepository: RepositoryBase<PersonRepository>,IPersonRepository
{
    internal PersonRepository(HandbookDbContext context) : base(context)
    {

    }
}