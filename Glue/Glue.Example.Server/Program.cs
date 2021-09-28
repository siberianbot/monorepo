using System.Threading;
using System.Threading.Tasks;
using Glue.Server.Infrastructure;
using Glue.Server.Models;

namespace Glue.Example.Server
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            GlueServer glueServer = new GlueServer(GlueServerOptions.Defaults);

            await glueServer.RunAsync(CancellationToken.None);
        }
    }
}