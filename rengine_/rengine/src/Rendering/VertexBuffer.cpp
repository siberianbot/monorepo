#include "VertexBuffer.hpp"

#include <sstream>

#include "../Common/Log.hpp"
#include "../Utils/Assert.hpp"

namespace rengine
{
    constexpr size_t vertexSize = sizeof(vertex_t);
    constexpr size_t indexSize = sizeof(index_t);

    static void mapVertexStruct()
    {
        glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, vertexSize, (void *) offsetof(vertex_t, position));
        glEnableVertexAttribArray(0);

        glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, vertexSize, (void *) offsetof(vertex_t, normal));
        glEnableVertexAttribArray(1);

        glVertexAttribPointer(2, 3, GL_FLOAT, GL_FALSE, vertexSize, (void *) offsetof(vertex_t, color));
        glEnableVertexAttribArray(2);

        glVertexAttribPointer(3, 2, GL_FLOAT, GL_FALSE, vertexSize, (void *) offsetof(vertex_t, texture));
        glEnableVertexAttribArray(3);
    }

    std::shared_ptr<VertexBuffer> VertexBuffer::create(const std::vector<vertex_t> &vertices,
                                                       const std::vector<index_t> &indices)
    {
        safeAssert(!vertices.empty(), "Vertex Buffer", "empty vertices array");
        safeAssert(!indices.empty(), "Vertex Buffer", "empty elements array");

        std::shared_ptr<VertexBuffer> buffer = std::make_shared<VertexBuffer>();
        buffer->_verticesCount = vertices.size();
        buffer->_elementsCount = indices.size() * 3;

        glGenVertexArrays(1, &buffer->_vao);
        glGenBuffers(2, buffer->_buffers);

        glBindVertexArray(buffer->_vao);

        glBindBuffer(GL_ARRAY_BUFFER, buffer->vbo());
        glBufferData(GL_ARRAY_BUFFER, buffer->_verticesCount * vertexSize, vertices.data(), GL_STATIC_DRAW);

        glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, buffer->ebo());
        glBufferData(GL_ELEMENT_ARRAY_BUFFER, indices.size() * indexSize, indices.data(), GL_STATIC_DRAW);

        mapVertexStruct();

        return buffer;
    }

    VertexBuffer::VertexBuffer() : _vao(0), _buffers(), _verticesCount(0), _elementsCount(0)
    {
        //
    }

    VertexBuffer::~VertexBuffer()
    {
        glDeleteBuffers(2, _buffers);
        glDeleteVertexArrays(1, &_vao);
    }

    void VertexBuffer::bind() const
    {
        glBindVertexArray(_vao);
    }
}