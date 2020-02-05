using Autofac;
using Nutrivida.Domain.Entities.FluentValidation;

namespace Nutrivida.IOC
{
    public static class InjectorValidations
    {
        public static void ConfigureValidations(this ContainerBuilder builder)
        {
            builder.RegisterType<AuthValidation>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpensiveCategoryValidation>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpensiveValidation>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<FinancialRecordValidation>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<SaleCategoryValidation>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<SaleValidation>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserValidation>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
