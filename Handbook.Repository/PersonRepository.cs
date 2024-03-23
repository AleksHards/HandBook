using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;

namespace Handbook.Repository;

public class PersonRepository: RepositoryBase<Person>,IPersonRepository
{
    internal PersonRepository(HandbookDbContext context) : base(context)
    {

    }
}