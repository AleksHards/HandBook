using Handbook.Service.RepositoryInterfaces;

namespace Handbook.Repository
{
    internal class UnitOfWork: IUnitOfWork
    {
        private readonly HandbookDbContext _context;
        private readonly Lazy<ICityRepository> _cityRepository;
        private readonly Lazy<IPersonRepository> _personRepository;
        private readonly Lazy<IPersonLinkRepository> _personLinkRepository;
        private readonly Lazy<IPhoneRepository> _phoneRepository;

        public UnitOfWork(HandbookDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(context));
            _personRepository = new Lazy<IPersonRepository>(() => new PersonRepository(context));
            _personLinkRepository = new Lazy<IPersonLinkRepository>(() => new PersonLinkRepository(context));
            _phoneRepository = new Lazy<IPhoneRepository>(() => new PhoneRepository(context));
        }

        public ICityRepository CityRepository => _cityRepository.Value;
        
        public IPersonLinkRepository PersonLinkRepository => _personLinkRepository.Value;

        public IPersonRepository PersonRepository => _personRepository.Value;

        public IPhoneRepository PhoneRepository => _phoneRepository.Value;

        public int SaveChanges() => _context.SaveChanges();

        public void BeginTransaction()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                throw new InvalidOperationException("A Transaction is already in progress.");
            }

            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                _context.Database.CurrentTransaction?.Commit();
            }
            catch
            {
                _context.Database.CurrentTransaction?.Rollback();
                throw;
            }
            finally
            {
                _context.Database.CurrentTransaction?.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                _context.Database.CurrentTransaction?.Rollback();
            }
            finally
            {
                _context.Database.CurrentTransaction?.Dispose();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
