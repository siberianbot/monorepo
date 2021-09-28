using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeamWorks.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static async Task ForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> asyncAction)
        {
            foreach (T item in enumerable)
            {
                await asyncAction(item);
            }
        }
    }
}