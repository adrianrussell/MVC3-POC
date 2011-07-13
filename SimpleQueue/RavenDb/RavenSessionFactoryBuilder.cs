using System.Diagnostics;
using Raven.Client.Document;

namespace Infrastructure.RavenDb
{
    public class RavenSessionFactoryBuilder : IRavenSessionFactoryBuilder
    {
        private IRavenSessionFactory _ravenSessionFactory;

        public IRavenSessionFactory GetSessionFactory()
        {
            return _ravenSessionFactory ?? (_ravenSessionFactory = CreateSessionFactory());
        }

        private static IRavenSessionFactory CreateSessionFactory()
        {
            Debug.Write("IRavenSessionFactory Created");
            return new RavenSessionFactory(new DocumentStore
                                           {
                                               Url = "http://localhost:8080"

                                           });
        }
    }
}