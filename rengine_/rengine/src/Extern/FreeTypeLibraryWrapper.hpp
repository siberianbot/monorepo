#ifndef RENGINE_SRC_EXTERN_FREETYPELIBRARYWRAPPER_HPP
#define RENGINE_SRC_EXTERN_FREETYPELIBRARYWRAPPER_HPP

#include <filesystem>
#include <memory>
#include <string>
#include <unordered_map>

#include <ft2build.h>
#include FT_FREETYPE_H

#include "ILibraryWrapper.hpp"
#include "../Rendering/TextRendering/Glyph.hpp"

namespace rengine
{
    /// Type of FreeType font.
    /// Contains font name and cached glyphs.
    class FreeTypeFont
    {
        friend class FreeTypeLibraryWrapper;

    public:
        /// Destroys instance of FreeType font and frees allocated memory for font face.
        ~FreeTypeFont();

        /// Loads glyph or returns it from cache.
        /// \param character Character of glyph.
        /// \param em Glyph point size.
        /// \return Shared instance of glyph.
        [[nodiscard]]
        std::shared_ptr<glyph_t> loadGlyph(const char &character, const int &em);

    private:
        std::u8string _name;
        FT_Face _face;
        std::unordered_map<glyph_key_t, std::shared_ptr<glyph_t>, glyph_key_hash_t> _glyphs;
    };

    /// FreeType library wrapper.
    /// \note FreeType uses for loading and managing fonts. All rendering is performed by
    ///  TextRenderer class.
    class FreeTypeLibraryWrapper : public ILibraryWrapper<FreeTypeLibraryWrapper>
    {
    public:
        /// Initializes FreeType library.
        void init() override;

        /// Terminates FreeType library (if it is possible).
        void terminate() override;

        /// Loads font from path or returns cached.
        /// \param path Path to font file.
        /// \return Shared instance of font.
        [[nodiscard]]
        std::weak_ptr<FreeTypeFont> loadFromPath(const std::filesystem::path &path);

    private:
        FT_Library _library;
        std::unordered_map<std::u8string, std::shared_ptr<FreeTypeFont>> _fonts;
    };
}

#endif //RENGINE_SRC_EXTERN_FREETYPELIBRARYWRAPPER_HPP
