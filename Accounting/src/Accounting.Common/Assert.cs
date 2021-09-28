using System;
using System.Runtime.CompilerServices;

namespace Accounting.Common
{
    public static class Assert
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNull<T>(T instance, string message = null)
        {
            if (instance != null)
            {
                throw new InvalidOperationException(message ?? "instance is not null");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNull<T>(T instance, string message = null)
        {
            if (instance == null)
            {
                throw new InvalidOperationException(message ?? "instance is null");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsEmpty(string str, string message = null)
        {
            if (!string.IsNullOrEmpty(str))
            {
                throw new InvalidOperationException(message ?? "string is not empty");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotEmpty(string str, string message = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new InvalidOperationException(message ?? "string is empty");
            }
        }
    }
}