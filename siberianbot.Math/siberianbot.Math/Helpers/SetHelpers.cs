using System.Linq;

namespace siberianbot.Math.Helpers
{
    public static class SetHelpers
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