#ifndef RENGINE_SRC_RENDERING_MESH_HPP
#define RENGINE_SRC_RENDERING_MESH_HPP

#include <memory>

#include <glm/vec3.hpp>
#include <glm/mat4x4.hpp>

#include "VertexBuffer.hpp"
#include "Texturing/Texture.hpp"

namespace rengine
{
    /// Type of mesh.
    /// Stores vertex buffer and texture, position, scale and rotation.
    typedef struct Mesh
    {
        /// Creates instance of mesh.
        explicit Mesh();

        /// Destroys mesh.
        ~Mesh();

        /// Shared instance of vertex buffer.
        std::shared_ptr<VertexBuffer> vertexBuffer;
        /// Shared instance of texture.
        // TODO: more textures
        std::shared_ptr<Texture> texture;
        /// Mesh position.
        glm::vec3 position;
        /// Mesh scale.
        glm::vec3 scale;
        /// Pitch angle.
        float pitch;
        /// Yaw angle.
        float yaw;
        /// Roll angle.
        float roll;
    } mesh_t;

    /// Calculates model matrix for provided mesh.
    /// \param mesh Mesh.
    /// \return Model matrix.
    [[nodiscard]]
    glm::mat4 modelMatrix(const mesh_t &mesh);
}

#endif //RENGINE_SRC_RENDERING_MESH_HPP
