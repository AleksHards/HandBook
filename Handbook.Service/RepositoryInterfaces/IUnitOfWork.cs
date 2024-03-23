namespace Handbook.Service.RepositoryInterfaces;

public interface IUnitOfWork : IDisposable
{
    ICityRepository CityRepository { get; }
    IPersonRepository PersonRepository { get; }
    IPersonLinkRepository PersonLinkRepository { get; }
    IContactRepository ContactRepository { get; }
    int SaveChanges();
    void BeginTransaction();
    void CommitTransaction();
    void Rollback();
}