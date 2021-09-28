#include "Viewport.hpp"

#include <glm/gtc/matrix_transform.hpp>

namespace rengine
{
    Viewport::Viewport()
            : type(ProjectionType::Perspective),
              position(0), up(0, 1, 0), target(0),
              width(0), height(0), near(0.001), far(100), fov(75), magnitude(1)
    {
        //
    }

    /// Calculates orthographic projection matrix.
    /// \param viewport Viewport for which this matrix will be calculated.
    /// \return Orthographic projection matrix.
    [[nodiscard]]
    static glm::mat4 orthographicProjectionMatrix(const viewport_t &viewport)
    {
        float aspect = viewport.aspect();

        return glm::ortho(-viewport.magnitude * aspect, viewport.magnitude * aspect,
                          -viewport.magnitude, viewport.magnitude,
                          viewport.near, viewport.far);
    }

    /// Calculates perspective projection matrix.
    /// \param viewport Viewport for which this matrix will be calculated.
    /// \return Perspective projection matrix.
    [[nodiscard]]
    static glm::mat4 perspectiveProjectionMatrix(const viewport_t &viewport)
    {
        return glm::perspective(viewport.fov, viewport.aspect(), viewport.near, viewport.far);
    }

    /// Calculates view matrix.
    /// \param viewport Viewport for which this matrix will be calculated.
    /// \return View matrix.
    [[nodiscard]]
    static glm::mat4 viewMatrix(const viewport_t &viewport)
    {
        // TODO: find out why up vector is incorrectly interpreted by LookAt
        return glm::lookAt(viewport.position, viewport.target, -viewport.up);
    }

    glm::mat4 viewportMatrix(const viewport_t &viewport)
    {
        glm::mat4 projection;

        switch (viewport.type)
        {
            case ProjectionType::Orthographic:
                projection = orthographicProjectionMatrix(viewport);
                break;

            case ProjectionType::Perspective:
                projection = perspectiveProjectionMatrix(viewport);
                break;

            default:
                throw;
        }

        return projection * viewMatrix(viewport);
    }
}