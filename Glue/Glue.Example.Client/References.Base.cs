using System.Collections.Generic;
using System.Threading.Tasks;
using Glue.Client.Infrastructure;
using Glue.Client.Models;
using Glue.Common.Infrastructure;
using Glue.Common.Models.Remote;

namespace Glue.Example.Client
{
    public sealed partial class References
    {
        private readonly GlueClient _glueClient;
        
        public References()
        {
            _glueClient = new GlueClient(GlueClientOptions.Defaults);
        }

        private async Task<GlueCallResponse> CallService(string service, string method, IDictionary<string, object> arguments)
        {
            GlueCall call = GlueCallFactory.Create(service, method, arguments);

            return await _glueClient.CallServiceAsync(call);
        }
    }
}