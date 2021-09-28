using System;
using ToDoList.Models;

namespace ToDoList.Web.Models.WorkItemApi
{
    public sealed class WorkItemViewModel
    {
        public long Id { get; set; }
        
        public WorkItemTypes Type { get; set; }
        
        public WorkItemPriorities? Priority { get; set; }
            
        public long? ParentWorkItemId { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string AssignedTo { get; set; }
        
        public DateTime CreationDate { get; set; }

        public DateTime? ExpectedCompletionDate { get; set; }

        public DateTime? ActualCompletionDate { get; set; }
    }
}