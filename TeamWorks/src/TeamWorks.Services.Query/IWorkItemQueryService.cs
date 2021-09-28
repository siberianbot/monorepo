using TeamWorks.DependencyInjection;
using TeamWorks.DomainModel;

namespace TeamWorks.Services.Query
{
    public interface IWorkItemQueryService : IQueryService<long, WorkItem>, IDependency
    {
        //
    }
}