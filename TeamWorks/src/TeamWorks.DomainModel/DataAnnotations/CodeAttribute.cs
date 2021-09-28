using System;

namespace TeamWorks.DomainModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class CodeAttribute : Attribute
    {
        public string Code { get; }

        public CodeAttribute(string code)
        {
            Code = code;
        }
    }
}