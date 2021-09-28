using System.Threading.Tasks;

namespace Accounting.Service.Infrastructure
{
    public interface IServiceMethodExecutor
    {
        Task<TResult> ExecuteAsync<TModel, TResult>(TModel model);
    }
}