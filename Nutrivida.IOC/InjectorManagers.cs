using Autofac;
using Nutrivida.Business.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrivida.IOC
{
    public static class InjectorManagers
    {
        public static void ConfigureManagers(this ContainerBuilder builder)
        {
            builder.RegisterType<NotificationManager>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
