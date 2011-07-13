using Ninject.Modules;

namespace RavenDBConsole
{
    public class ConsoleModule : NinjectModule
    {
        public override void Load() {
            Bind<ICreateBankersCommand>().To<CreateBankersCommand>().InSingletonScope();
        }
    }
}
