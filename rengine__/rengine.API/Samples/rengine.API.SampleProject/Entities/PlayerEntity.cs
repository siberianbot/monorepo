using rengine.API.Annotations;
using rengine.API.Components;
using rengine.API.Entities;

namespace rengine.API.SampleProject.Entities
{
    /// <summary>
    /// Sample player entity.
    /// </summary>
    [IncludeComponents(typeof(PositionComponent))]
    public sealed class PlayerEntity : Entity
    {
        //
    }
}