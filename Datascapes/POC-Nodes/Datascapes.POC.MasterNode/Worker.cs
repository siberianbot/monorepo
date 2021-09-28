using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Datascapes.POC.MasterNode
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                string msg = Console.ReadLine() ?? string.Empty;
                byte[] msgBytes = Encoding.UTF8.GetBytes(msg).Append((byte) 0x04).ToArray();

                using TcpClient client = new TcpClient("localhost", 9000);

                await client.GetStream().WriteAsync(msgBytes, stoppingToken);
            }
        }
    }
}