using System;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;

namespace TeamWorks.DependencyInjection.Extensions
{
    public static class ContainerBuilderExtensions
    {
        private static Assembly[] AppDomainAssemblies
        {
            get => AppDomain.CurrentDomain.GetAssemblies();
        }

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterInterface(this ContainerBuilder @this, Type interfaceType)
        {
            return @this.RegisterAssemblyTypes(AppDomainAssemblies)
                .Where(interfaceType.IsAssignableFrom)
                .AsSelf()
                .AsImplementedInterfaces();
        }
    }
}