using ToDoList.Models;

namespace ToDoList.Web.Models.WorkItemApi
{
    public sealed class WorkItemSummaryViewModel
    {
        public long Id { get; set; }
        
        public long? ParentWorkItemId { get; set; }
        
        public WorkItemTypes Type { get; set; }
        
        public string Title { get; set; }
    }
}