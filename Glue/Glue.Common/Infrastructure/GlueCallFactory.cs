using System.Collections.Generic;
using Glue.Common.Models.Remote;

namespace Glue.Common.Infrastructure
{
    public static class GlueCallFactory
    {
        public static GlueCall Create(string service, string method, IDictionary<string, object> args)
        {
            return new GlueCall
            {
                GlueVersion = Constants.GlueVersion,
                Service = service,
                Method = method,
                Arguments = GlueArgumentFactory.CreateArray(args)
            };
        }
    }
}