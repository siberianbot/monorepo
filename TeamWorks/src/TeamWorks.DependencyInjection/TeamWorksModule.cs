using System;
using System.Linq;
using Autofac;

namespace TeamWorks.DependencyInjection
{
    public abstract class TeamWorksModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            Type[] dependencyTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(IDependency).IsAssignableFrom(type))
                .Where(type => !type.IsInterface && !type.IsAbstract)
                .ToArray();

            foreach (Type dependency in dependencyTypes)
            {
                if (dependency.IsGenericType)
                {
                    Type[] genericInterfaces = dependency.GetInterfaces()
                        .Where(@interface => @interface.IsGenericType)
                        .ToArray();
                    
                    builder.RegisterGeneric(dependency.GetGenericTypeDefinition())
                        .AsSelf()
                        .As(genericInterfaces)
                        .InstancePerLifetimeScope();
                }
                else
                {
                    builder.RegisterType(dependency)
                        .AsSelf()
                        .AsImplementedInterfaces()
                        .InstancePerLifetimeScope();
                }
            }
        }
    }
}