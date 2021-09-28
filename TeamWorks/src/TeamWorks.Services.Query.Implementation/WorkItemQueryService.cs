using JetBrains.Annotations;
using TeamWorks.DataAccess;
using TeamWorks.DomainModel;

namespace TeamWorks.Services.Query.Implementation
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal class WorkItemQueryService : QueryServiceBase<long, WorkItem>, IWorkItemQueryService
    {
        public WorkItemQueryService(IReadRepository<long, WorkItem> readRepository)
            : base(readRepository)
        {
            //
        }
    }
}