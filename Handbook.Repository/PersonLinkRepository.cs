using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Handbook.Repository;

internal class PersonLinkRepository : RepositoryBase<PersonLink>, IPersonLinkRepository
{
    protected HandbookDbContext _context;

    internal PersonLinkRepository(HandbookDbContext context) : base(context)
    {
        _context = context;
    }

    internal IEnumerable<Person> GetPeople(int id)
    {
         return _context.PersonLinks.Where(x => x.PersonFrom.Id == id)
            .Select(t => t.PersonTo)
            .Concat(
                _context.PersonLinks
                .Where(x => x.PersonTo.Id == id)
                .Select(f => f.PersonFrom))
            .AsNoTracking()
            .ToList();
    }
}