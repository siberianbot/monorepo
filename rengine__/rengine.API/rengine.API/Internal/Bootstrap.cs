using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace rengine.API.Internal
{
    // ReSharper disable once UnusedType.Global
    internal static partial class Bootstrap
    {
        private static Assembly _applicationAssembly;

        [UnmanagedCallersOnly]
        // ReSharper disable once UnusedMember.Global
        public static bool Init(InitParams initParams)
        {
            try
            {
                string assemblyPath = Marshal.PtrToStringUTF8(initParams.AssemblyPathPtr);
            
                InitializeAssembly(assemblyPath);
                InitializeApplication();

                return true;
            }
            catch (Exception exception)
            {
                // TODO: use engine logging
                Console.WriteLine(exception.Message);
                
                return false;
            }
        }

        private static void InitializeAssembly(string assemblyPath)
        {
            if (!File.Exists(assemblyPath))
            {
                throw GetException(Resources.ExceptionMessages.Bootstrap_AssemblyNotFound);
            }

            _applicationAssembly = Assembly.LoadFile(assemblyPath);
        }

        private static void InitializeApplication()
        {
            Type applicationType = typeof(Application);

            TypeInfo[] applicationTypes = _applicationAssembly.DefinedTypes
                .Where(type => type.BaseType == applicationType)
                .Take(2)
                .ToArray();

            Application.Current = applicationTypes.Length == 1
                ? (Application) Activator.CreateInstance(applicationTypes[0])
                : throw GetException(string.Format(Resources.ExceptionMessages.Bootstrap_ApplicationNotFound, applicationType.FullName));
        }

        private static Exception GetException(string message)
        {
            return new Exception(message);
        }
    }
}