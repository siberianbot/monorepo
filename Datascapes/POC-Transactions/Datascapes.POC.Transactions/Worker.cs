using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Datascapes.POC.Transactions
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
                string cmd = Console.ReadLine();

                if (string.IsNullOrEmpty(cmd))
                {
                    continue;
                }

                string[] tokens = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 0)
                {
                    continue;
                }

                switch (tokens[0])
                {
                    case "new":
                        // TODO
                        break;
                    
                    default:
                        _logger.LogError("Invalid token: {Token}", tokens[0]);
                        break;
                }
            }
        }
    }
}