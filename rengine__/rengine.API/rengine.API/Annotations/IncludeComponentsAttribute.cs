using System;
using System.Linq;
using rengine.API.Components;

namespace rengine.API.Annotations
{
    /// <summary>
    /// Includes component or components to entity.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class IncludeComponentsAttribute : Attribute
    {
        /// <summary>
        /// Component types which are described on initialization of this attribute.
        /// </summary>
        public Type[] ComponentTypes { get; }

        /// <summary>
        /// Creates instance of attribute.
        /// </summary>
        /// <param name="componentTypes">Types of components which are inherited from <see cref="Component"/> class.</param>
        /// <exception cref="ArgumentOutOfRangeException">Passed types of components contains one or more types which are not inherited from <see cref="Component"/> class.</exception>
        public IncludeComponentsAttribute(params Type[] componentTypes)
        {
            if (componentTypes.Any(type => type.BaseType != typeof(Component)))
            {
                throw new ArgumentOutOfRangeException(nameof(componentTypes),
                    string.Format(Resources.ExceptionMessages.IncludeComponentsAttribute_UnacceptableType, nameof(IncludeComponentsAttribute), nameof(Component)));
            }

            ComponentTypes = componentTypes;
        }
    }
}