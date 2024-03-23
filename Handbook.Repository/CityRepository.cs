using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;

namespace Handbook.Repository;

public class CityRepository : RepositoryBase<City>, ICityRepository
{
    internal CityRepository(HandbookDbContext context) : base(context)
    {

    }
}