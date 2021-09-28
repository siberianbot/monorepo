#include "TextureAtlas.hpp"

#include <glad/glad.h>

#include "../Renderer.hpp"

namespace rengine
{
    /// Creates new node.
    /// \param rect
    /// \return
    std::shared_ptr<TextureAtlasNode> createNode(const uint32_t &id, const uint32_rect_t &rect)
    {
        TextureAtlasNode node = {};
        node.data.id = id;
        node.data.rect = rect;

        return std::make_shared<TextureAtlasNode>(node);
    }

    /// Searches for good nodes - nodes, that can fit a rectangle of some size.
    /// \param node
    /// \param size
    /// \return
    std::shared_ptr<TextureAtlasNode> findGoodNode(const std::shared_ptr<TextureAtlasNode> &node,
                                                   const uint32_size_t &size)
    {
        if (!node->data.isEmpty() ||
            (node->data.rect.size.width < size.width &&
             node->data.rect.size.height < size.height))
        {
            return nullptr;
        }

        std::shared_ptr<TextureAtlasNode> result;

        if (!node->left)
        {
            uint32_rect_t leftRect;
            uint32_rect_t rightRect;

            uint32_t dw = node->data.rect.size.width - size.width;
            uint32_t dh = node->data.rect.size.height - size.height;

            leftRect.position = node->data.rect.position;
            leftRect.size = size;

            if (dw > dh)
            {
                rightRect.position = {
                    node->data.rect.position.x + size.width,
                    node->data.rect.position.y
                };
                rightRect.size = {
                    dw,
                    node->data.rect.size.height
                };
            }
            else
            {
                rightRect.position = {
                    node->data.rect.position.x,
                    node->data.rect.position.y + size.height
                };
                rightRect.size = {
                    node->data.rect.size.width,
                    dh
                };
            }

            node->left = createNode(leftRect);
            node->right = createNode(rightRect);

            result = node->left;
        }
        else
        {
            result = findGoodNode(node->left, size);

            if (result == nullptr)
            {
                result = findGoodNode(node->right, size);
            }
        }

        return result;
    }

    TextureAtlas::TextureAtlas(const GLuint &textureId, const GLenum &format, const uint32_size_t &size) :
        _textureId(textureId), _format(format), _size(size)
    {
        _root = createNode({{0, 0}, size});
    }

    std::byte *TextureAtlas::dump()
    {
        return nullptr;
    }

    std::uint32_t TextureAtlas::insert(std::byte *image, const uint32_size_t &size, std::uint32_t)
    {
        return 0;
    }

    uint32_rect_t TextureAtlas::getTexture(const uint32_t &id)
    {
        return rengine::uint32_rect_t();
    }

    void TextureAtlas::bind()
    {
        glBindTexture(GL_TEXTURE_2D, _textureId);
    }

    TextureAtlas::~TextureAtlas()
    {
        glDeleteTextures(1, &_textureId);
    }

    std::shared_ptr<TextureAtlas> TextureAtlasFactory::create(const uint32_size_t &size, const GLenum &format)
    {
        static std::uint32_t maxTextureSize = Renderer::instance()->maxTextureSize();
        uint32_t width = size.width > 0 ? size.width : maxTextureSize;
        uint32_t height = size.height > 0 ? size.height : maxTextureSize;

        GLuint texture;
        glGenTextures(1, &texture);

        glBindTexture(GL_TEXTURE_2D, texture);

        return std::shared_ptr<TextureAtlas>();
    }
}