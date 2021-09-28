using System;
using System.Collections.Generic;
using System.Linq;
using Accounting.Service.Infrastructure.Implementation;
using Autofac;

namespace Accounting.Service
{
    public abstract class ServiceModule : Module
    {
        protected virtual IEnumerable<Type> ServiceMethods
        {
            get => Enumerable.Empty<Type>();
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ServiceMethodExecutor>()
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            foreach (Type serviceMethod in ServiceMethods)
            {
                builder.RegisterType(serviceMethod)
                    .AsSelf()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            }
        }
    }
}