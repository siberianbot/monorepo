#ifndef RENGINE_SRC_RENDERING_BUFFER_HPP
#define RENGINE_SRC_RENDERING_BUFFER_HPP

#include <memory>
#include <vector>

#include <glm/vec2.hpp>
#include <glm/vec3.hpp>
#include <glm/vec4.hpp>

#include <glad/glad.h>

namespace rengine
{
    typedef struct vertex
    {
        glm::vec3 position;
        glm::vec2 textureCoord;
        glm::vec4 color;
    } vertex_t;

    typedef struct bufferParams
    {
        std::vector<vertex_t> vertices;
        std::vector<glm::ivec3> elements;
    } buffer_params_t;

    class buffer
    {
    public:
        friend class bufferFactory;

        explicit buffer();

        ~buffer();

        void use() const;
        void destroy();

    private:
        GLuint _array;
        GLuint _buffers[2];

        [[nodiscard]]
        GLuint vbo() const { return _buffers[0]; }
        [[nodiscard]]
        GLuint ebo() const { return _buffers[1]; }
    };

    class bufferFactory
    {
    public:
        static std::shared_ptr<buffer> create(const buffer_params_t &params);
    };
}

#endif //RENGINE_SRC_RENDERING_BUFFER_HPP
