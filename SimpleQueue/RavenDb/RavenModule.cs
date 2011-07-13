using Ninject;
using Ninject.Modules;
using Raven.Client;

namespace Infrastructure.RavenDb
{
    public class RavenModule : NinjectModule
    {
        public override void Load()
        {
            // Ravendb Session
            Bind<IRavenSessionFactoryBuilder>().To<RavenSessionFactoryBuilder>().InSingletonScope();
            Bind<IDocumentSession>().ToMethod(context => Kernel.Get<IRavenSessionFactoryBuilder>().GetSessionFactory().CreateSession());

            // Ravendb Repository
            Bind<IRepository>().To<RavenRepository>();

        }

    }
}