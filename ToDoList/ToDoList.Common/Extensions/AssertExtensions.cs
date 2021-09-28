using System.Linq;

namespace ToDoList.Common.Extensions
{
    public static class AssertExtensions
    {
        public static bool IsIn<T>(this T value, params T[] possibleValues)
        {
            return possibleValues.Contains(value);
        }

        public static bool IsNotIn<T>(this T value, params T[] possibleValues)
        {
            return !possibleValues.Contains(value);
        }
    }
}