using rengine.API.Components;
using rengine.API.Extensions;

namespace rengine.API.Entities
{
    /// <summary>
    /// Abstract entity class, which should be used by any entity in application.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Entity instance identifier. This identifier is unique. 
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Entity instance name. Multiple entities can share one name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Collection of entity components.
        /// </summary>
        public ComponentCollection Components { get; }

        /// <summary>
        /// Creates instance of entity.
        /// </summary>
        protected Entity()
        {
            Components = ComponentCollection.CreateFor(GetType());

            EntityRegistrar.Instance.Add(this);
        }

        /// <summary>
        /// Updates entity state.
        /// </summary>
        /// <param name="passed">Passed time from previous update.</param>
        public virtual void Update(float passed)
        {
            Components.ForEach(c => c.Update(passed));
        }

        /// <summary>
        /// Destroys instance of entity.
        /// </summary>
        public virtual void Destroy()
        {
            Components.ForEach(c => c.Destroy());

            EntityRegistrar.Instance.Remove(this);
        }
    }
}