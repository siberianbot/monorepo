using Accounting.Service.Models;

namespace Accounting.Service.Builders
{
    public interface IServiceMethodBuilder
    {
        IServiceMethodBuilder WithEndpoint(string method, string path);

        IServiceMethodBuilder WithModel<TModel>();

        IServiceMethodBuilder WithResult<TResult>();

        ServiceMethodEndpoint Build();
    }
}