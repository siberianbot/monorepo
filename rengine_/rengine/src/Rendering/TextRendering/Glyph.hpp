#ifndef RENGINE_SRC_RENDERING_TEXTRENDERING_GLYPH_HPP
#define RENGINE_SRC_RENDERING_TEXTRENDERING_GLYPH_HPP

#include <vector>

#include <glad/glad.h>

#include "../../Utils/Types.hpp"

namespace rengine
{
    /// Type of glyph key for storing in unordered map.
    typedef struct GlyphKey
    {
        /// Character of glyph.
        char character;
        /// Glyph point size.
        int em;
    } glyph_key_t;

    /// Type of hash function for glyph key.
    typedef struct GlyphKeyHash
    {
        /// Calculates hash.
        /// \param key Glyph key.
        /// \return Key hash.
        size_t operator()(const glyph_key_t &key) const;
    } glyph_key_hash_t;

    /// Equality operator for glyph_key_t.
    /// \param lhs First key.
    /// \param rhs Second key.
    /// \return True if keys are same.
    bool operator==(const glyph_key_t &lhs, const glyph_key_t &rhs);

    /// Type of glyph.
    /// Uses for storing some important information about glyph, like character,
    /// size, bearing, advance and cached bitmap.
    typedef struct Glyph
    {
        /// OpenGL texture identity.
        // TODO: there should be used our texture, but our texture factory is not flexible as it should be
        GLuint textureId;
        /// Character of glyph.
        char character;
        /// Size of glyph.
        uint_size_t size;
        /// Glyph bearing.
        int_size_t bearing;
        /// Horizontal glyph advance.
        int advance;
        /// Glyph bitmap.
        std::vector<unsigned char> bitmap;
    } glyph_t;

}

#endif //RENGINE_SRC_RENDERING_TEXTRENDERING_GLYPH_HPP
