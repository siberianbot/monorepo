#ifndef RENGINE_SRC_RENDERING_TEXTURING_TEXTURE_ATLAS_HPP
#define RENGINE_SRC_RENDERING_TEXTURING_TEXTURE_ATLAS_HPP

#include <cstdint>
#include <memory>
#include <vector>

#include "Texture.hpp"
#include "../../Common/ISingleton.hpp"
#include "../../Utils/Types.hpp"

namespace rengine
{
    /// Type of texture data in texture atlas.
    struct TextureAtlasData
    {
        /// Identity of node. There is a texture if value is non-zero.
        std::uint32_t id;
        /// Texture rectangle.
        uint32_rect_t rect;

        /// Checks that data is empty (see id fields).
        [[nodiscard]]
        bool isEmpty() const { return id == 0; }
    };

    /// Type for texture atlas inner tree structure.
    /// This tree is used for storing information about texture location.
    struct TextureAtlasNode
    {
        /// Data.
        TextureAtlasData data;
        /// Left child node.
        std::shared_ptr<TextureAtlasNode> left;
        /// Right child node.
        std::shared_ptr<TextureAtlasNode> right;
    };

    /// A big enough texture that uses as storage for smaller textures.
    class TextureAtlas
    {
    public:
        explicit TextureAtlas(const GLuint &textureId, const GLenum &format, const uint32_size_t &size);

        ~TextureAtlas();

        [[nodiscard]]
        std::uint32_t insert(std::byte *image, const uint32_size_t &size, std::uint32_t);

        uint32_rect_t getTexture(const uint32_t &id);

        void bind();

        std::byte *dump();

    private:
        GLuint _textureId;
        GLenum _format;
        uint32_size_t _size;
        std::uint32_t _id;
        std::shared_ptr<TextureAtlasNode> _root;
    };

    class TextureAtlasFactory : ISingleton<TextureAtlasFactory>
    {
    public:
        static std::shared_ptr<TextureAtlas> create(const uint32_size_t &size, const GLenum &format);
    };
}

#endif //RENGINE_SRC_RENDERING_TEXTURING_TEXTURE_ATLAS_HPP
