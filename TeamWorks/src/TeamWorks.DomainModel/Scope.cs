using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamWorks.DomainModel
{
    /// <summary>
    /// Security scope.
    /// </summary>
    public class Scope : Entity<long>
    {
        /// <summary>
        /// Scope name.
        /// </summary>
        [Required]
        public virtual string Name { get; set; }

        #region Foreign Keys

        /// <summary>
        /// Parent scope id.
        /// </summary>
        public virtual long ParentScopeId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Parent scope.
        /// </summary>
        public virtual Scope ParentScope { get; set; }
        
        /// <summary>
        /// Child scopes.
        /// </summary>
        public virtual ICollection<Scope> ChildScopes { get; set; } 

        #endregion
    }
}