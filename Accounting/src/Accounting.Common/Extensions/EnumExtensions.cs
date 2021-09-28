using System;
using System.Reflection;

namespace Accounting.Common.Extensions
{
    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TEnum, TAttribute>(this TEnum value)
            where TEnum : struct, Enum
            where TAttribute : Attribute
        {
            Type enumType = typeof(TEnum);
            string name = Enum.GetName(enumType, value);

            return enumType.GetMember(name!)[0].GetCustomAttribute<TAttribute>();
        }
    }
}