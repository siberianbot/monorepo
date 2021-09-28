using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Datascapes.POC.StorageNode
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
            TcpListener listener = TcpListener.Create(9000);
            
            listener.Start();
            
            while (!stoppingToken.IsCancellationRequested)
            {
                Socket socket = await listener.AcceptSocketAsync();

                _ = Task.Run(() => HandleAsync(socket, stoppingToken), stoppingToken);
            }
            
            listener.Stop();
        }

        private async Task HandleAsync(Socket socket, CancellationToken cancellationToken)
        {
            Pipe pipe = new Pipe();

            Task receiveTask = ReceiveAsync(socket, pipe.Writer);
            Task readingTask = ReadAsync(pipe.Reader);

            Task.WaitAll(receiveTask, readingTask);
        }

        private async Task ReceiveAsync(Socket socket, PipeWriter writer)
        {
            Memory<byte> memory = writer.GetMemory(512);

            while (true)
            {
                int count = await socket.ReceiveAsync(memory, SocketFlags.None);

                if (count == 0)
                {
                    break;
                }
                
                writer.Advance(count);

                FlushResult result = await writer.FlushAsync();

                if (result.IsCompleted)
                {
                    break;
                }
            }
            
            await writer.CompleteAsync();
        }

        private async Task ReadAsync(PipeReader reader)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            while (true)
            {
                ReadResult result = await reader.ReadAsync();
                ReadOnlySequence<byte> buffer = result.Buffer;

                while (TryRead(ref buffer, out ReadOnlySequence<byte> line))
                {
                    string data = Encoding.UTF8.GetString(line);
                    
                    stringBuilder.Append(data);
                }

                reader.AdvanceTo(buffer.Start, buffer.End);

                if (result.IsCompleted)
                {
                    break;
                }
            }

            _logger.LogInformation("{Message}", stringBuilder.ToString());
            
            await reader.CompleteAsync();
        }

        private bool TryRead(ref ReadOnlySequence<byte> buffer, out ReadOnlySequence<byte> line)
        {
            SequencePosition? position = buffer.PositionOf((byte) 0x04);

            if (position == null)
            {
                line = default;
                return false;
            }

            line = buffer.Slice(0, position.Value);
            buffer = buffer.Slice(buffer.GetPosition(1, position.Value));

            return true;
        }
    }
}