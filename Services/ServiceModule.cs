using Ninject.Modules;

namespace Services
{
    public class ServiceModule : NinjectModule
    {
        public override void Load() {
            Bind<IBankerService>().To<BankerService>().InSingletonScope();
            Bind<IProductService>().To<ProductService>().InSingletonScope();
        }
    }
}