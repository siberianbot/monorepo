using System.Linq;
using JetBrains.Annotations;

namespace TeamWorks.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsIn<T>(this T value, [ItemCanBeNull] params T[] values) => values.Contains(value);

        public static bool IsNotIn<T>(this T value, [ItemCanBeNull] params T[] values) => !values.Contains(value);
    }
}