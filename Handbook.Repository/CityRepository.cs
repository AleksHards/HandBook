using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;

namespace Handbook.Repository;

internal sealed class CityRepository : RepositoryBase<City>, ICityRepository
{
    internal CityRepository(HandbookDbContext context) : base(context)
    {

    }
}