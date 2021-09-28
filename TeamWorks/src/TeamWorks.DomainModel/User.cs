using System;
using System.ComponentModel.DataAnnotations;
using TeamWorks.DomainModel.DataContracts;

namespace TeamWorks.DomainModel
{
    public class User : Entity<long>, IScopedEntity, IAuditedEntity
    {
        [Required]
        [StringLength(250)]
        public virtual string Email { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string FirstName { get; set; }

        [StringLength(100)]
        public virtual string MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string LastName { get; set; }

        [StringLength(100)]
        public virtual string NickName { get; set; }

        #region IScopedEntity

        [Required]
        public virtual long? ScopeId { get; set; }

        public virtual Scope Scope { get; set; }

        #endregion

        #region IAuditedEntity

        [Required]
        public virtual DateTime? CreationDate { get; set; }

        [Required]
        public virtual long? CreationUserId { get; set; }

        [Required]
        public virtual DateTime? LastModifiedDate { get; set; }

        [Required]
        public virtual long? LastModifiedUserId { get; set; }

        #endregion
    }
}