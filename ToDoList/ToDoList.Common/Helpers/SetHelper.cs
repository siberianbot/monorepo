using System.Linq;

namespace ToDoList.Common.Helpers
{
    public static class SetHelper
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