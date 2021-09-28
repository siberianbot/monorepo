#include "Texture.hpp"

namespace rengine
{
    Texture::Texture() : _id(0), _hash(0), _width(0), _height(0)
    {
        //
    }

    Texture::~Texture()
    {
        glDeleteTextures(1, &_id);
    }

    void Texture::bind() const
    {
        glBindTexture(GL_TEXTURE_2D, _id);
    }
}
