using System;
using System.Reflection;
using Glue.Common.Models;

namespace Glue.Server.Providers.Defaults
{
    public class DefaultServiceProvider : IServiceProvider
    {
        public Type ResolveService(string service)
        {
            return Assembly.GetEntryAssembly()?.GetType(service)
                   ?? throw new GlueException("Service type not found", null);
        }

        public MethodInfo ResolveMethod(Type service, string method)
        {
            return service.GetMethod(method)
                   ?? throw new GlueException("Service method not found", null);
        }

        public object GetInstance(Type serviceType)
        {
            return Activator.CreateInstance(serviceType);
        }
    }
}