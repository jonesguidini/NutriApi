using Autofac;
using Nutrivida.Data.Repositories;
using Nutrivida.Domain.Contracts.Repositories;

namespace Nutrivida.IOC
{
    /// <summary>
    /// Injeta os repositories no autofac
    /// </summary>
    public static class InjectorRepositories
    {
        /// <summary>
        /// Configura os repositories
        /// </summary>
        /// <param name="builder">Container do autofac</param>
        public static void ConfigureRepositories(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepositoryBase<>));
            //builder.RegisterGeneric(typeof(BaseIdentityRepository<>)).As(typeof(IIdentityRepository<>));

            builder.RegisterAssemblyTypes(typeof(RepositoryBase<>).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        }
    }
}
