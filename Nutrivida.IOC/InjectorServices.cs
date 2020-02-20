using Autofac;
using Nutrivida.Business.Services;
using Nutrivida.Domain.Contracts.Services;

namespace Nutrivida.IOC
{
    public static class InjectorServices
    {
        public static void ConfigureServices(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ServiceBase<>)).As(typeof(IServiceBase<>));

            builder.RegisterAssemblyTypes(typeof(ServiceBase<>).Assembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        }
    }
}
