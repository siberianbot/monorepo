using System;

namespace Accounting.Service.Models
{
    public sealed class ServiceMethodEndpoint
    {
        public string Method { get; init; }

        public string Path { get; init; }

        public Type ModelType { get; init; }

        public Type ResultType { get; init; }
    }
}