using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using TeamWorks.DomainModel.DataContracts;

namespace TeamWorks.DomainModel
{
    public class WorkItem : Entity<long>, IScopedEntity
    {
        [Required]
        [StringLength(100)]
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        #region Foreign Keys

        [Required]
        public virtual long? StatusId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Status Status { get; set; }

        #endregion

        public WorkItemStatus GetWorkItemStatus()
        {
            Debug.Assert(StatusId != null, nameof(StatusId) + " != null");
            return (WorkItemStatus) StatusId;
        }

        public void SetWorkItemStatus(WorkItemStatus value)
        {
            StatusId = (long) value;
        }

        #region IScopedEntity

        public virtual long? ScopeId { get; set; }

        public virtual Scope Scope { get; set; }

        #endregion
    }
}