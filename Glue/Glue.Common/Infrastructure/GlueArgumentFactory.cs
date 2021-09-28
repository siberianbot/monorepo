using System.Collections.Generic;
using System.Linq;
using Glue.Common.Helpers;
using Glue.Common.Models.Remote;

namespace Glue.Common.Infrastructure
{
    public static class GlueArgumentFactory
    {
        public static GlueArgument Create(string name, object value)
        {
            return new GlueArgument
            {
                GlueVersion = Constants.GlueVersion,
                Name = name,
                Value = SerializationHelper.SerializeObject(value, value.GetType())
            };
        }

        public static GlueArgument[] CreateArray(IDictionary<string, object> args)
        {
            return args.Select(arg => Create(arg.Key, arg.Value)).ToArray();
        }
    }
}