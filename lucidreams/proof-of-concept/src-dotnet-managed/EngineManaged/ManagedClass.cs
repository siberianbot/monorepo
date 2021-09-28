using System;
using System.Runtime.InteropServices;

namespace EngineManaged
{
    public static class ManagedClass
    {
        [UnmanagedCallersOnly]
        public static int Invoke()
        {
            Console.WriteLine("ManagedClass invoked.");

            return 42;
        }
    }
}