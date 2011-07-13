namespace Infrastructure.RavenDb
{
    public interface IRepository
    {
        T Store<T>(T item);
    }
}
