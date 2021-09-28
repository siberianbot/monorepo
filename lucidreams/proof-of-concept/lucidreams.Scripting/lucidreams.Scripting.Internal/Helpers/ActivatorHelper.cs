using System;
using System.Reflection;

namespace lucidreams.Scripting.Internal.Helpers
{
    internal static class ActivatorHelper
    {
        public static object CreateInstance(Type type, params object[] args)
        {
            // TODO:
            // https://andrewlock.net/benchmarking-4-reflection-methods-for-calling-a-constructor-in-dotnet/
            // we can make it better
            return Activator.CreateInstance(type, BindingFlags.Public | BindingFlags.Instance, args);
        }
    }
}