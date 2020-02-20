using Autofac;
using Nutrivida.Domain.Contracts.FluentValidation;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.Entities.FluentValidation;

namespace Nutrivida.IOC
{
    public static class InjectorValidations
    {
        public static void ConfigureValidations(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(FluentValidation<>)).As(typeof(IFluentValidation<>));

            builder.RegisterAssemblyTypes(typeof(FluentValidation<>).Assembly)
            .Where(t => t.Name.EndsWith("Validation"))
            .InstancePerLifetimeScope();
        }
    }
}
