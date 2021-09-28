#include "Framebuffer.hpp"

namespace rengine
{
    Framebuffer::Framebuffer() : _id(0)
    {
        //
    }

    Framebuffer::~Framebuffer()
    {
        glDeleteFramebuffers(1, &_id);
    }

    void Framebuffer::bind() const
    {
        glBindFramebuffer(GL_FRAMEBUFFER, _id);
    }
}