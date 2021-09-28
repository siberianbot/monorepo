using System.Net;

namespace siberianbot.GenshinImpact.Mockingbird
{
    internal class RequestHandlerCollection
    {
        private const int MaxHandlersCount = 1024;

        private readonly RequestHandler[] _handlers;

        public RequestHandlerCollection()
        {
            // TODO: make configurable
            _handlers = new RequestHandler[MaxHandlersCount];
        }

        public RequestHandler Handle(HttpListenerContext context)
        {
            int idx;

            while ((idx = _handlers.IndexOf(handler => handler == null || handler.IsFinished)) == -1)
            {
                //
            }

            _handlers[idx] = new RequestHandler(context);

            return _handlers[idx];
        }

        public bool AreFinished
        {
            get => _handlers.IndexOf(handler => handler != null && !handler.IsFinished) == -1;
        }
    }
}