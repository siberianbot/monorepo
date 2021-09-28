using System;
using System.Collections.Generic;

namespace rengine.API.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IEnumerable{T}"/>. 
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Invokes action to all items in collection
        /// </summary>
        /// <param name="collection">Collection, that implements <see cref="IEnumerable{T}"/>.</param>
        /// <param name="action">Action which should be invoked for item.</param>
        /// <typeparam name="T">Type of items in collection.</typeparam>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (T item in collection)
            {
                action(item);
            }
        }
    }
}