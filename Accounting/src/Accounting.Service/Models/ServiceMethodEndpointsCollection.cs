using System.Collections.Generic;

namespace Accounting.Service.Models
{
    public sealed class ServiceMethodEndpointsCollection
    {
        public IReadOnlyList<ServiceMethodEndpoint> Endpoints { get; init; }
    }
}