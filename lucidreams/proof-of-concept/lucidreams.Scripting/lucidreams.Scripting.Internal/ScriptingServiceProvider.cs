using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using lucidreams.Scripting.Internal.Helpers;

namespace lucidreams.Scripting.Internal
{
    internal sealed class ScriptingServiceProvider : IServiceProvider
    {
        private readonly Type[] _dependencies;
        private readonly Dictionary<Type, object> _instances;

        public ScriptingServiceProvider()
        {
            Type injectableInterfaceType = typeof(IInjectable);

            _dependencies = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => injectableInterfaceType.IsAssignableFrom(type))
                .Where(type => !type.IsAbstract)
                .ToArray();

            _instances = new Dictionary<Type, object>();
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (_instances.TryGetValue(serviceType, out object instance))
            {
                return instance;
            }

            instance = serviceType.IsGenericType && serviceType.GetGenericTypeDefinition() == typeof(Lazy<>)
                ? ResolveLazyServiceInstance(serviceType)
                : ResolveServiceInstance(serviceType);

            _instances.Add(serviceType, instance);

            return instance;
        }

        private object ResolveServiceInstance(Type serviceType)
        {
            Type implementationType = _dependencies.FirstOrDefault(serviceType.IsAssignableFrom);

            if (implementationType == null)
            {
                throw new InvalidOperationException($"There is no implementation of {serviceType}.");
            }

            if (implementationType.IsGenericTypeDefinition)
            {
                throw new NotImplementedException("Generic type definitions are not supported right now.");
            }

            return GetServiceInstance(serviceType, implementationType);
        }
        
        private object ResolveLazyServiceInstance(Type lazyServiceType)
        {
            Type serviceType = lazyServiceType.GetGenericArguments()[0];
            Type funcType = typeof(Func<>).MakeGenericType(serviceType);

            object factoryInstance = ActivatorHelper.CreateInstance(funcType, (Func<object>) (() => GetService(serviceType)));

            return ActivatorHelper.CreateInstance(lazyServiceType, factoryInstance, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        private object GetServiceInstance(Type serviceType, Type implementationType)
        {
            ConstructorInfo[] constructors = implementationType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            if (constructors.Length > 1)
            {
                throw new InvalidOperationException($"{implementationType} (implementation of {serviceType}) have many constructors.");
            }

            if (constructors.Length == 0)
            {
                return ActivatorHelper.CreateInstance(implementationType);
            }

            ParameterInfo[] parameters = constructors[0].GetParameters();
            object[] parametersInstances = new object[parameters.Length];

            for (int idx = 0; idx < parameters.Length; idx++)
            {
                parametersInstances[idx] = GetService(parameters[idx].ParameterType);
            }

            return ActivatorHelper.CreateInstance(implementationType, parametersInstances);
        }
    }
}