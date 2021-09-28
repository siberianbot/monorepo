using System.Threading.Tasks;
using HiveMind.Services.Common;

namespace HiveMind.Services.Query
{
    public interface ISampleService : IService
    {
        Task ExecuteAsync();
    }
}