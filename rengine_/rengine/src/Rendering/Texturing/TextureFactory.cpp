#include "TextureFactory.hpp"

#include <cstddef>

#define STB_IMAGE_IMPLEMENTATION
#include <stb_image.h>

#include "../../Utils/Assert.hpp"

namespace rengine
{
    std::shared_ptr<Texture> TextureFactory::loadFromFile(const load_from_file_args_t &args)
    {
        int width, height, channels;
        std::byte *image;
        std::shared_ptr<Texture> texture;

        stbi_set_flip_vertically_on_load(args.flipVertically);
        image = reinterpret_cast<std::byte*>(stbi_load(args.path.string().c_str(), &width, &height, &channels, 0));
        engineAssert(image != nullptr, "Texture Factory", "texture is not loaded");

        texture = TextureFactory::generateTexture();

        glBindTexture(GL_TEXTURE_2D, texture->_id);
        // TODO: this parameters should be extracted from... somewhere
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST_MIPMAP_NEAREST);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
        // TODO: some of this parameters should depend on type of file
        glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, width, height, 0, GL_RGBA, GL_UNSIGNED_BYTE, image);
        // TODO: made generation of mipmaps optional
        glGenerateMipmap(GL_TEXTURE_2D);

        stbi_image_free(image);

        texture->_name = args.path.filename().u8string();
        // TODO: calculate hash of image
        texture->_width = width;
        texture->_height = height;

        return texture;
    }

    std::shared_ptr<Texture> TextureFactory::generateTexture()
    {
        std::shared_ptr<Texture> texture = std::make_shared<Texture>();

        GLuint textureId;
        glGenTextures(1, &textureId);

        texture->_id = textureId;

        return texture;
    }

}