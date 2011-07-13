using Raven.Client.Document;

namespace Infrastructure.RavenDb
{
    public class RavenRepository : IRepository
    {
        private readonly DocumentStore _store;

        public RavenRepository()
        {
            _store = new DocumentStore { Url = "http://localhost:8080" };
            _store.Initialize();
        }

        public T Store<T>(T item)
        {
            using (var session = _store.OpenSession())
            {
                session.Store(item);
                session.SaveChanges();
            }
            return item;
        }
    }
}