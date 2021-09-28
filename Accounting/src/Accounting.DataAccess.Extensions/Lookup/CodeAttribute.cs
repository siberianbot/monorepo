using System;

namespace Accounting.DataAccess.Extensions.Lookup
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class CodeAttribute : Attribute
    {
        public CodeAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}