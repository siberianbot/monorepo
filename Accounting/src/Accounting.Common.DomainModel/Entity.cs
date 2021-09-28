using System.ComponentModel.DataAnnotations;

namespace Accounting.Common.DomainModel
{
    public abstract class Entity<TKey> : IEntity
    {
        [Key]
        public virtual TKey Id { get; set; }

        object IEntity.Id
        {
            get => Id;
        }
    }
}