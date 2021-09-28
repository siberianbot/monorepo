using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ToDoList.Models
{
    public class Task : Entity
    {
        [Required]
        [StringLength(255)]
        public virtual string Title { get; set; }

        [StringLength(2048)]
        public virtual string Description { get; set; }

        [Required]
        [StringLength(255)]
        public virtual string AssignedTo { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public virtual int RemainingTime { get; set; }

        [Range(1, int.MaxValue)]
        public virtual int? ActualTime { get; set; }

        [Required]
        public virtual DateTime? CreationDate { get; set; }

        [Required]
        public virtual DateTime? LastModifiedDate { get; set; }
        
        public virtual DateTime? CompleteDate { get; set; }

        #region Foreign keys

        public virtual long? ParentTaskId { get; set; }

        [Required]
        public virtual long? StatusId { get; set; }

        #endregion

        #region Navigation properties

        public virtual Task ParentTask { get; set; }
        
        public virtual ICollection<Task> ChildTasks { get; set; }

        public virtual Status Status { get; set; }

        #endregion

        public TaskStatus GetStatus()
        {
            Debug.Assert(StatusId != null, nameof(StatusId) + " != null");
            
            return (TaskStatus)StatusId;
        }

        public void SetStatus(TaskStatus status)
        {
            StatusId = (long) status;
        }
    }
}