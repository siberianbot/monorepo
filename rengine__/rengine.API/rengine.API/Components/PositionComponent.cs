using System.Numerics;

namespace rengine.API.Components
{
    /// <summary>
    /// Defines position in three dimensional space.
    /// </summary>
    public sealed class PositionComponent : Component
    {
        /// <summary>
        /// <see cref="Vector3"/> with object location.
        /// </summary>
        public Vector3 Location { get; set; }
        
        /// <summary>
        /// <see cref="Vector3"/> with object rotation.
        /// <remarks>(X, Y, Z) corresponds to (Pitch, Yaw, Roll).</remarks>
        /// </summary>
        public Vector3 Rotation { get; set; }
    }
}