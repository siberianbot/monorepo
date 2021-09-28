#ifndef RENGINE_SRC_RENDERING_VERTEXBUFFER_HPP
#define RENGINE_SRC_RENDERING_VERTEXBUFFER_HPP

#include <memory>
#include <vector>

#include <glad/glad.h>
#include <glm/vec2.hpp>
#include <glm/vec3.hpp>

namespace rengine
{
    /// Type of three dimensional vertex which uses in vertex buffer.
    typedef struct Vertex
    {
        /// Vertex position.
        glm::vec3 position;
        /// Normal vector.
        glm::vec3 normal;
        /// Vertex color (uses in texture blending).
        glm::vec3 color;
        /// Texture uv-coordinates.
        glm::vec2 texture;
    } vertex_t;

    /// Typedef of index for element buffer.
    typedef glm::u32vec3 index_t;

    /// Type of vertex buffer.
    /// Contains OpenGL identities of vertex array, vertex buffer and element buffer objects.
    class VertexBuffer
    {
    public:
        /// Creates shared instance of vertex buffer.
        /// \param vertices Array of vertices.
        /// \param indices Array of indices.
        /// \return Shared instance of vertex buffer.
        [[nodiscard]]
        static std::shared_ptr<VertexBuffer> create(const std::vector<vertex_t> &vertices,
                                                    const std::vector<index_t> &indices);

        /// Creates instance of vertex buffer.
        explicit VertexBuffer();

        /// Destroys instance of vertex buffer and deletes all allocated OpenGL objects.
        ~VertexBuffer();

        /// Binds vertex array object.
        void bind() const;

        /// Returns count of vertices in vertex buffer.
        /// \return Count of vertices.
        [[nodiscard]]
        size_t getVerticesCount() const { return _verticesCount; }

        /// Returns count of elements in vertex buffer.
        /// \return Count of elements.
        [[nodiscard]]
        size_t getElementsCount() const { return _elementsCount; }

    private:
        GLuint _vao;
        GLuint _buffers[2];
        size_t _verticesCount;
        size_t _elementsCount;

        /// Returns identity of vertex buffer object.
        /// \return Identity of vertex buffer object.
        [[nodiscard]]
        GLuint vbo() const { return _buffers[0]; }

        /// Returns identity of element buffer object.
        /// \return Identity of element buffer object.
        [[nodiscard]]
        GLuint ebo() const { return _buffers[1]; }
    };
}

#endif //RENGINE_SRC_RENDERING_VERTEXBUFFER_HPP
