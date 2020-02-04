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

            builder.RegisterType<AuthRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpensiveCategoryRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpensiveRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<FinancialRecordsRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<LogRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<SaleCategoryRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<SaleRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
