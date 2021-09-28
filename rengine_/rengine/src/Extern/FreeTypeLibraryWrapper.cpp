#include "FreeTypeLibraryWrapper.hpp"

#include <utility>

#include "../Common/Log.hpp"
#include "../Utils/Assert.hpp"

namespace rengine
{
    FreeTypeFont::~FreeTypeFont()
    {
        safeAssert(!FT_Done_Face(_face), "FreeType", "failed to unload font");
    }

    std::shared_ptr<glyph_t> FreeTypeFont::loadGlyph(const char &character, const int &em)
    {
        glyph_key_t key = {character, em};

        auto iterator = _glyphs.find(key);
        if (iterator != _glyphs.end())
        {
            return iterator->second;
        }

        FT_Set_Pixel_Sizes(_face, 0, em);

        if (FT_Load_Char(_face, character, FT_LOAD_RENDER))
        {
            Log::instance()->error("FreeType", "failed to load glyph for character %0", character);
            return nullptr;
        }

        std::shared_ptr<glyph_t> glyph = std::make_shared<glyph_t>();

        unsigned int bitmapSize = _face->glyph->bitmap.width * _face->glyph->bitmap.rows;
        glyph->bitmap.assign(_face->glyph->bitmap.buffer, _face->glyph->bitmap.buffer + bitmapSize);
        glyph->character = character;
        glyph->size = {_face->glyph->bitmap.width, _face->glyph->bitmap.rows};
        glyph->bearing = {_face->glyph->bitmap_left, _face->glyph->bitmap_top};
        glyph->advance = _face->glyph->advance.x;

        _glyphs[key] = glyph;

        return glyph;
    }

    GENERATE_SINGLETON_INSTANCE(FreeTypeLibraryWrapper);

    void FreeTypeLibraryWrapper::init()
    {
        engineAssert(!FT_Init_FreeType(&_library), "FreeType", "failed to load library");
    }

    void FreeTypeLibraryWrapper::terminate()
    {
        safeAssert(!FT_Done_FreeType(_library), "FreeType", "failed to unload library");
    }

    std::weak_ptr<FreeTypeFont> FreeTypeLibraryWrapper::loadFromPath(const std::filesystem::path &path)
    {
        auto iterator = _fonts.find(path.u8string());
        if (iterator != _fonts.end())
        {
            return iterator->second;
        }

        FT_Face face;
        if (FT_New_Face(_library, path.string().c_str(), 0, &face))
        {
            Log::instance()->error("FreeType", "failed to load font by path %0", path);
            return std::weak_ptr<FreeTypeFont>();
        }

        std::shared_ptr<FreeTypeFont> font = std::make_shared<FreeTypeFont>();

        font->_face = face;
        font->_name = path.filename().u8string();

        _fonts[font->_name] = font;

        return font;
    }
}