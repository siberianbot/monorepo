using System;
using System.Reflection;

namespace Glue.Server.Providers
{
    public interface IServiceProvider
    {
        public Type ResolveService(string service);
        
        public MethodInfo ResolveMethod(Type service, string method);

        public object GetInstance(Type serviceType);
    }
}