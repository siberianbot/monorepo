#include "buffer.hpp"

namespace rengine
{
    buffer::buffer() : _array(0)
    {
        //
    }

    buffer::~buffer()
    {
        if (_array != 0)
        {
            destroy();
        }
    }

    void buffer::use() const
    {
        glBindVertexArray(_array);
    }

    void buffer::destroy()
    {
        glDeleteVertexArrays(1, &_array);
        glDeleteBuffers(2, _buffers);
    }

    std::shared_ptr<buffer> bufferFactory::create(const buffer_params_t &params)
    {
        std::shared_ptr<buffer> ptr = std::make_shared<buffer>();

        glGenVertexArrays(1, &ptr->_array);
        glGenBuffers(2, ptr->_buffers);

        glBindVertexArray(ptr->_array);

        glBindBuffer(GL_ARRAY_BUFFER, ptr->vbo());
        glBufferData(GL_ARRAY_BUFFER, sizeof(vertex_t) * params.vertices.size(), params.vertices.data(),
                     GL_STATIC_DRAW);

        glBindBuffer(GL_ARRAY_BUFFER, ptr->ebo());
        glBufferData(GL_ARRAY_BUFFER, sizeof(glm::ivec3) * params.elements.size(), params.elements.data(),
                     GL_STATIC_DRAW);

        glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 3 * sizeof(float), (void *) 0);
        glVertexAttribPointer(1, 2, GL_FLOAT, GL_FALSE, 2 * sizeof(float), (void *) (3 * sizeof(float)));
        glVertexAttribPointer(2, 4, GL_FLOAT, GL_FALSE, 4 * sizeof(float), (void *) (5 * sizeof(float)));
        glEnableVertexAttribArray(0);

        return ptr;
    }
}