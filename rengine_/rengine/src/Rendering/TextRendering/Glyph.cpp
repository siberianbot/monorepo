#include "Glyph.hpp"

namespace rengine
{
    size_t GlyphKeyHash::operator()(const glyph_key_t &key) const
    {
        // TODO: I think, it is incorrect way to calculate hash of key
        return std::hash<char>()(key.character) ^ std::hash<int>()(key.em);
    }

    bool operator==(const glyph_key_t &lhs, const glyph_key_t &rhs)
    {
        return lhs.em == rhs.em &&
               lhs.character == rhs.character;
    }
}