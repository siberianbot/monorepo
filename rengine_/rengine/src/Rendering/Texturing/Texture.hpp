#ifndef RENGINE_SRC_RENDERING_TEXTURE_HPP
#define RENGINE_SRC_RENDERING_TEXTURE_HPP

#include <string>

#include <glad/glad.h>

namespace rengine
{
    class TextureFactory;

    /// Texture type.
    /// Uses for storing identity of texture.
    class Texture
    {
        friend class TextureFactory;

    public:
        /// Creates instance of texture.
        explicit Texture();

        /// Destroys instance of texture and deletes OpenGL identity.
        ~Texture();

        /// Returns hash of texture.
        /// \return Hash of texture.
        [[nodiscard]]
        size_t getHash() const { return _hash; }

        /// Returns name of texture.
        /// \return Name of texture.
        [[nodiscard]]
        std::u8string getName() const { return _name; }

        /// Returns width of texture.
        /// \return Width of texture.
        [[nodiscard]]
        size_t getWidth() const { return _width; }

        /// Returns height of texture.
        /// \return Height of texture.
        [[nodiscard]]
        size_t getHeight() const { return _height; }

        /// Bind this texture and use it in rendering.
        void bind() const;

    private:
        GLuint _id;
        std::u8string _name;
        size_t _hash;
        size_t _width;
        size_t _height;
    };
}

#endif //RENGINE_SRC_RENDERING_TEXTURE_HPP
