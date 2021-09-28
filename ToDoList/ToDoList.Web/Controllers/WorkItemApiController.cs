using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using ToDoList.Services.Query;
using ToDoList.Web.Models.WorkItemApi;

namespace ToDoList.Web.Controllers
{
    [Route("api/workitem")]
    public sealed class WorkItemApiController : ApiControllerBase
    {
        private readonly IWorkItemQueryService _workItemQueryService;

        public WorkItemApiController(IWorkItemQueryService workItemQueryService)
        {
            _workItemQueryService = workItemQueryService;
        }

        [Route("{id:long?}")]
        public async Task<IActionResult> GetWorkItems(long? id, int? count, int? offset)
        {
            IQueryable<WorkItem> query = _workItemQueryService.GetAll()
                .Where(item => item.ParentWorkItemId == id);

            if (offset != null)
            {
                query = query.Skip(offset.Value);
            }

            if (count != null)
            {
                query = query.Take(count.Value);
            }

            WorkItemSummaryViewModel[] result = await query
                .Select(workItem => new WorkItemSummaryViewModel
                {
                    Id = workItem.Id,
                    ParentWorkItemId = workItem.ParentWorkItemId,
                    Type = (WorkItemTypes) workItem.TypeId,
                    Title = workItem.Title
                }).ToArrayAsync();

            return new JsonResult(result);
        }

        [Route("{id:long}/detail")]
        public async Task<IActionResult> GetById(long id)
        {
            WorkItem workItem = await _workItemQueryService.GetByIdAsync(id);

            if (workItem == null)
            {
                // TODO: l10n
                throw new DomainException("Work Item not found");
            }

            WorkItemViewModel viewModel = new WorkItemViewModel
            {
                Id = workItem.Id,
                ParentWorkItemId = workItem.ParentWorkItemId,

                Type = workItem.GetWorkItemType(),
                Priority = workItem.GetPriority(),

                Title = workItem.Title,
                Description = workItem.Description,
                AssignedTo = workItem.AssignedTo,

                CreationDate = workItem.CreationDate,
                ExpectedCompletionDate = workItem.ExpectedCompletionDate,
                ActualCompletionDate = workItem.ActualCompletionDate
            };

            return new JsonResult(viewModel);
        }
    }
}