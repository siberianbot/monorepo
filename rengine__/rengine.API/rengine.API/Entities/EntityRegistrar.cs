using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace rengine.API.Entities
{
    /// <summary>
    /// Keep track of all entities. 
    /// </summary>
    public sealed class EntityRegistrar
    {
        #region Static instance

        /// <summary>
        /// Static instance of entity registrar.
        /// </summary>
        public static EntityRegistrar Instance { get; }

        static EntityRegistrar()
        {
            Instance = new EntityRegistrar();
        }

        #endregion

        #region Private fields

        private readonly List<Entity> _entities = new List<Entity>();
        private long _counter;

        #endregion

        internal void Add(Entity entity)
        {
            Interlocked.Increment(ref _counter);
            entity.Id = _counter;

            _entities.Add(entity);
        }

        internal void Remove(Entity entity)
        {
            _entities.Remove(entity);
        }

        /// <summary>
        /// Get entities by name.
        /// </summary>
        /// <param name="name">Entity name.</param>
        /// <returns>Collection of entities with specified name.</returns>
        public IEnumerable<Entity> GetByName(string name)
        {
            return _entities.Where(entity => entity.Name == name);
        }
    }
}