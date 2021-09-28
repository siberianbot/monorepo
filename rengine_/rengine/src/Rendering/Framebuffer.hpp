#ifndef RENGINE_SRC_RENDERING_FRAMEBUFFER_HPP
#define RENGINE_SRC_RENDERING_FRAMEBUFFER_HPP

#include <glad/glad.h>

namespace rengine
{
    class Framebuffer
    {
    public:
        explicit Framebuffer();

        ~Framebuffer();

        void bind() const;

    private:
        GLuint _id;
    };
}

#endif //RENGINE_SRC_RENDERING_FRAMEBUFFER_HPP
