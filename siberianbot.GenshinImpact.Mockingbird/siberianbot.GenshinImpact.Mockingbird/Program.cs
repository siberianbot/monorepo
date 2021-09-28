using System;
using System.Threading;
using System.Threading.Tasks;

namespace siberianbot.GenshinImpact.Mockingbird
{
    internal static class Program
    {
        public static Task Main(string[] args)
        {
            using ProxyServer proxyServer = ProxyServerFactory.Create(args);

            CancellationTokenSource cts = new CancellationTokenSource();

            Console.CancelKeyPress += (_, eventArgs) =>
            {
                if (cts.IsCancellationRequested)
                {
                    return;
                }

                eventArgs.Cancel = true;

                cts.Cancel();
            };
            
            return proxyServer.RunAsync(cts.Token);
        }
    }
}