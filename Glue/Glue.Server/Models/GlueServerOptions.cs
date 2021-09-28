using Glue.Common;
using Glue.Server.Providers;
using Glue.Server.Providers.Defaults;

namespace Glue.Server.Models
{
    public sealed class GlueServerOptions
    {
        public string Endpoint { get; set; }

        public IServiceProvider ServiceProvider { get; set; }

        public static GlueServerOptions Defaults
        {
            get => new GlueServerOptions
            {
                Endpoint = Constants.GlueEndpoint,
                ServiceProvider = new DefaultServiceProvider()
            };
        }
    }
}