namespace Handbook.Service.RepositoryInterfaces
{
    public interface IEntity<out T>
    {
        T Id { get; }
    }

    public interface IEntity : IEntity<int>
    {

    }
}
