using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace siberianbot.GenshinImpact.Mockingbird
{
    internal class RequestHandler
    {
        private readonly HttpListenerContext _context;
        private readonly Task _handlerTask;

        public RequestHandler(HttpListenerContext context)
        {
            _context = context;

            IsFinished = false;
            _handlerTask = Task.Run(HandlerFunc);
        }

        public bool IsFinished
        {
            get;
            private set; // TODO
        }

        private async Task HandlerFunc()
        {
            using HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(_context.Request.HttpMethod), _context.Request.Url);
            
            foreach (string key in _context.Request.Headers.AllKeys)
            {
                if (key == null)
                {
                    throw new InvalidOperationException("Header without key"); // wtf?
                }
                
                request.Headers.Add(key, _context.Request.Headers[key]);
            }
            
            request.Content = new StreamContent(_context.Request.InputStream);

            using HttpClient httpClient = new HttpClient();
            using HttpResponseMessage response = await httpClient.SendAsync(request);

            await using Stream outputStream = await response.Content.ReadAsStreamAsync();
            await outputStream.CopyToAsync(_context.Response.OutputStream);

            foreach ((string key, IEnumerable<string> values) in response.Headers)
            {
                _context.Response.Headers.Add(key, string.Join(";", values));
            }

            IsFinished = true;
        }
    }
}