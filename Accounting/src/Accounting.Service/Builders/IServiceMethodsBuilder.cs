using Accounting.Service.Models;

namespace Accounting.Service.Builders
{
    public interface IServiceMethodsBuilder
    {
        IServiceMethodBuilder Endpoint();
        
        ServiceMethodEndpointsCollection Build();
    }
}