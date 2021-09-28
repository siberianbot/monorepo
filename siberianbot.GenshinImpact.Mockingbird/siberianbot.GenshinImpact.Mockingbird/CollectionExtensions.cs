using System;
using System.Collections.Generic;

namespace siberianbot.GenshinImpact.Mockingbird
{
    internal static class CollectionExtensions
    {
        /// <summary>
        /// Returns index of first element which matches predicate.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int IndexOf<T>(this IList<T> collection, Predicate<T> predicate)
        {
            for (int idx = 0; idx < collection.Count; idx++)
            {
                if (predicate(collection[idx]))
                {
                    return idx;
                }
            }

            return -1;
        }
    }
}