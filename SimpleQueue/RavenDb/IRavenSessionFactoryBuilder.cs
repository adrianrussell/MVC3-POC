namespace Infrastructure.RavenDb
{
    public interface IRavenSessionFactoryBuilder
    {
        IRavenSessionFactory GetSessionFactory();
    }
}