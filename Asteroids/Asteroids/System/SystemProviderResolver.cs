using System;
using Asteroids.System.Core.Abstractions;
using Asteroids.System.Win32;

namespace Asteroids.System
{
    public static class SystemProviderResolver
    {
        public static ISystemProvider Resolve()
        {
            return Environment.OSVersion.Platform switch
            {
                PlatformID.Win32NT => new Win32SystemProvider(),
                
                _ => throw new NotSupportedException($"{Environment.OSVersion} is not supported")
            };
        }
    }
}