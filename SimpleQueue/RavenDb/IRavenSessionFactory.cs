using Raven.Client;

namespace Infrastructure.RavenDb
{
    public interface IRavenSessionFactory
    {
        IDocumentSession CreateSession();
    }
}