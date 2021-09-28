using System.Threading.Tasks;

namespace Accounting.Service.Infrastructure
{
    public interface IServiceMethod<in TModel, TResult>
    {
        Task<TResult> ExecuteAsync(TModel model);
    }
}