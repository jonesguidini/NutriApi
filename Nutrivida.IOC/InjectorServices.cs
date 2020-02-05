using System;
using System.Collections.Generic;
using System.Text;
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

            builder.RegisterType<AuthService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpensiveCategoryService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpensiveService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<FinancialRecordsService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<LogService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<SaleCategoryService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<SaleService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
