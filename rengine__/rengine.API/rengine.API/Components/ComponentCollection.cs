using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using rengine.API.Annotations;
using rengine.API.Extensions;

namespace rengine.API.Components
{
    /// <summary>
    /// Special class for storing all entity's components.
    /// </summary>
    public sealed class ComponentCollection : IEnumerable<Component>
    {
        #region Private fields and constructor

        private readonly List<Component> _components;

        private ComponentCollection()
        {
            _components = new List<Component>();
        }

        #endregion

        /// <summary>
        /// Add component of type <see cref="TComponent"/> to entity.
        /// </summary>
        /// <typeparam name="TComponent">Component type.</typeparam>
        /// <exception cref="InvalidOperationException">Throws if entity already contains component of type TComponent.</exception>
        public void Add<TComponent>()
            where TComponent : Component
        {
            Add(typeof(TComponent));
        }

        private void Add(Type componentType)
        {
            if (_components.Any(c => c.GetType() == componentType))
            {
                throw new InvalidOperationException(string.Format(Resources.ExceptionMessages.ComponentCollection_ComponentAlreadyExists, componentType.Name));
            }

            Component component = (Component) Activator.CreateInstance(componentType);

            _components.Add(component);
        }

        /// <summary>
        /// Returns instance of existing component.
        /// </summary>
        /// <typeparam name="TComponent">Component type.</typeparam>
        /// <returns>Instance of existing component or null, if it is not exists.</returns>
        public TComponent Get<TComponent>()
            where TComponent : Component
        {
            Type componentType = typeof(TComponent);
            return (TComponent) _components.SingleOrDefault(c => c.GetType() == componentType);
        }

        #region IEnumerable<Component>

        /// <summary>
        /// Returns an enumerator that iterates through the component collection.
        /// </summary>
        /// <returns>Enumerator.</returns>
        public IEnumerator<Component> GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the component collection.
        /// </summary>
        /// <returns>Enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        #endregion

        internal static ComponentCollection CreateFor(Type entityType)
        {
            ComponentCollection collection = new ComponentCollection();

            entityType.GetCustomAttribute<IncludeComponentsAttribute>()?.ComponentTypes.ForEach(component => collection.Add(component));

            return collection;
        }
    }
}