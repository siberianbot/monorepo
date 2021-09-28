#ifndef RENGINE_SRC_RENDERING_VIEWPORT_HPP
#define RENGINE_SRC_RENDERING_VIEWPORT_HPP

#include <glm/vec2.hpp>
#include <glm/vec3.hpp>
#include <glm/mat4x4.hpp>

namespace rengine
{
    /// Viewport projection type.
    enum class ProjectionType
    {
        Orthographic,
        Perspective
    };

    /// Viewport type.
    /// Stores viewport dimensions, distance of near and far planes,
    /// projection type, position, up vector and target, etc.
    typedef struct Viewport
    {
        /// Creates instance of viewport
        explicit Viewport();

        /// Type of projection.
        ProjectionType type;
        /// Position of viewport.
        glm::vec3 position;
        /// Up vector.
        glm::vec3 up;
        /// Position of target.
        glm::vec3 target;
        /// Viewport width.
        int width;
        /// Viewport height.
        int height;
        /// Near plane distance.
        float near;
        /// Far plane distance.
        float far;
        /// Field of view in degrees (for perspective projection).
        float fov;
        /// Magnitude (for orthographic projection).
        float magnitude;

        /// Calculates aspect ratio based on viewport width and height.
        /// \return Aspect ratio.
        [[nodiscard]]
        float aspect() const { return (float) width / (float) height; }
    } viewport_t;

    /// Calculates multiplication of projection and view matrices.
    /// \param viewport Viewport for which this matrix will be calculated.
    /// \return Result of multiplication of projection and view matrices.
    [[nodiscard]]
    glm::mat4 viewportMatrix(const viewport_t &viewport);
}

#endif //RENGINE_SRC_RENDERING_VIEWPORT_HPP
