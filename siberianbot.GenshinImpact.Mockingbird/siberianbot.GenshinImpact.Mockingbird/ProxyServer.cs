using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace siberianbot.GenshinImpact.Mockingbird
{
    internal class ProxyServer : IDisposable
    {
        private readonly HttpListener _listener;
        private readonly RequestHandlerCollection _handlerCollection;

        public ProxyServer()
        {
            _listener = new HttpListener();
            _handlerCollection = new RequestHandlerCollection();
        }
        
        public async Task RunAsync(CancellationToken cancellationToken)
        {
            if (_listener.IsListening)
            {
                throw new InvalidOperationException("Already running");
            }

            // TODO
            _listener.Prefixes.Add("https://sdk-os-static.mihoyo.com/");
            _listener.Prefixes.Add("https://dispatchosglobal.yuanshen.com/");
            _listener.Prefixes.Add("https://webstatic-sea.mihoyo.com/");
            _listener.Prefixes.Add("https://osasiadispatch.yuanshen.com/");
            _listener.Prefixes.Add("https://oseurodispatch.yuanshen.com/");
            _listener.Prefixes.Add("https://osusadispatch.yuanshen.com/");
            _listener.Prefixes.Add("https://hk4e-sdk-os.mihoyo.com/");
            _listener.Prefixes.Add("http://overseauspider.yuanshen.com:8888/");

            _listener.Start();
            
            while (!cancellationToken.IsCancellationRequested)
            {
                HttpListenerContext context = await _listener.GetContextAsync();

                _handlerCollection.Handle(context);
            }

            while (!_handlerCollection.AreFinished)
            {
                // TODO: wait until all handlers are done
            }

            _listener.Stop();
        }
        
        #region IDisposable

        private bool _disposed = false;

        ~ProxyServer()
        {
            Dispose(false);
        }
        
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposeManaged)
        {
            if (_disposed)
            {
                return;
            }

            if (disposeManaged)
            {
                ((IDisposable) _listener).Dispose();
            }

            _disposed = true;

            GC.SuppressFinalize(this);            
        }

        #endregion
    }
}