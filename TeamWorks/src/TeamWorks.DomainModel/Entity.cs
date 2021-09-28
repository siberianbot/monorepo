using System.ComponentModel.DataAnnotations;
using TeamWorks.DomainModel.DataContracts;

namespace TeamWorks.DomainModel
{
    /// <summary>
    /// Base entity class.
    /// </summary>
    /// <typeparam name="TKey">Type of key.</typeparam>
    public class Entity<TKey> : IEntity
    {
        /// <summary>
        /// Id of entity. 
        /// </summary>
        [Key]
        [Required]
        public virtual TKey Id { get; set; }

        /// <inheritdoc />
        object IEntity.Id
        {
            get => Id;
        }
    }
}