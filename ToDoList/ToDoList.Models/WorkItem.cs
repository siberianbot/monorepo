using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class WorkItem
    {
        [Key]
        public virtual long Id { get; set; }

        [Required]
        [StringLength(255)]
        public virtual string Title { get; set; }

        [StringLength(4096)]
        public virtual string Description { get; set; }

        [StringLength(255)]
        public virtual string AssignedTo { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual DateTime? ExpectedCompletionDate { get; set; }

        public virtual DateTime? ActualCompletionDate { get; set; }

        #region Foreign key

        [Required]
        public virtual long? TypeId { get; set; }

        public virtual long? PriorityId { get; set; }

        public virtual long? ParentWorkItemId { get; set; }

        #endregion

        #region Navigation properties

        public virtual WorkItemType Type { get; set; }

        public virtual WorkItemPriority Priority { get; set; }

        public virtual WorkItem ParentWorkItem { get; set; }

        public WorkItemTypes GetWorkItemType()
        {
            return (WorkItemTypes) TypeId!;
        }

        public void SetWorkItemType(WorkItemTypes type)
        {
            TypeId = (long) type;
        }

        public WorkItemPriorities? GetPriority()
        {
            return (WorkItemPriorities?) PriorityId;
        }

        public void SetPriority(WorkItemPriorities? priority)
        {
            PriorityId = (long?) priority;
        }

        #endregion
    }
}