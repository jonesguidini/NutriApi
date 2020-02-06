using Autofac;
using Nutrivida.Domain.Contracts.FluentValidation;
using Nutrivida.Domain.Entities.FluentValidation;

namespace Nutrivida.IOC
{
    public static class InjectorValidations
    {
        public static void ConfigureValidations(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ValidationBase<>)).As(typeof(IFluentValidation<>));

            builder.RegisterType<AuthValidation>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpensiveCategoryValidation>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpensiveValidation>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FinancialRecordValidation>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SaleCategoryValidation>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SaleValidation>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserValidation>()
                .InstancePerLifetimeScope();
        }
    }
}
