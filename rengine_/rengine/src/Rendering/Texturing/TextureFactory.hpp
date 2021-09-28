#ifndef RENGINE_SRC_RENDERING_TEXTUREFACTORY_HPP
#define RENGINE_SRC_RENDERING_TEXTUREFACTORY_HPP

#include <filesystem>
#include <memory>

#include "Texture.hpp"

namespace rengine
{
    /// Type of arguments for loading texture from file.
    typedef struct TextureFactoryLoadFromFileArgs
    {
        /// Path to file.
        std::filesystem::path path;
        /// Flip loaded image vertically.
        bool flipVertically;
    } load_from_file_args_t;

    /// Texture factory class.
    /// Creates shared instances to texture.
    class TextureFactory
    {
    public:
        /// Loads texture from file.
        /// \param args Arguments for loading texture from file.
        /// \return Shared instance of texture.
        [[nodiscard]]
        static std::shared_ptr<Texture> loadFromFile(const load_from_file_args_t &args);

    private:
        /// Generates texture.
        /// \return Shared pointer to texture.
        [[nodiscard]]
        static std::shared_ptr<Texture> generateTexture();
    };
}

#endif //RENGINE_SRC_RENDERING_TEXTUREFACTORY_HPP
