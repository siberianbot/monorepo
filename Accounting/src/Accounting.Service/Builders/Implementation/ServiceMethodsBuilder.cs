using System.Collections.Generic;
using System.Linq;
using Accounting.Service.Models;

namespace Accounting.Service.Builders.Implementation
{
    internal sealed class ServiceMethodsBuilder : IServiceMethodsBuilder
    {
        private readonly List<IServiceMethodBuilder> _builders = new List<IServiceMethodBuilder>();

        public IServiceMethodBuilder Endpoint()
        {
            ServiceMethodBuilder builder = new ServiceMethodBuilder();

            _builders.Add(builder);

            return builder;
        }

        public ServiceMethodEndpointsCollection Build()
        {
            return new ServiceMethodEndpointsCollection
            {
                Endpoints = _builders
                    .Select(builder => builder.Build())
                    .ToList()
            };
        }
    }
}