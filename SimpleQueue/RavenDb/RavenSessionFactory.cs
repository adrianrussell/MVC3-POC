using System.Diagnostics;
using Raven.Client;

namespace Infrastructure.RavenDb
{
    public class RavenSessionFactory : IRavenSessionFactory
    {
        private readonly IDocumentStore _documentStore;

        public RavenSessionFactory(IDocumentStore documentStore)
        {
            if (_documentStore != null) return;

            _documentStore = documentStore;
            _documentStore.Initialize();
        }

        public IDocumentSession CreateSession()
        {
            Debug.Write("IDocumentSession Created");
            return _documentStore.OpenSession();
        }
    }
}