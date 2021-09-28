using Glue.Common;

namespace Glue.Client.Models
{
    public sealed class GlueClientOptions
    {
        public string Endpoint { get; set; }

        public static GlueClientOptions Defaults
        {
            get => new GlueClientOptions
            {
                Endpoint = Constants.GlueEndpoint
            };
        }
    }
}