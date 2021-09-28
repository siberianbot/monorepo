#ifndef RENGINE_SRC_RENDERING_SHADERFACTORY_HPP
#define RENGINE_SRC_RENDERING_SHADERFACTORY_HPP

#include <filesystem>
#include <memory>

#include <glad/glad.h>

#include "Shader.hpp"

namespace rengine
{
    /// Type of arguments for loading shader program from files.
    typedef struct ShaderFactoryLoadFromFileArgs
    {
        /// Path to vertex shader.
        std::filesystem::path vertexShader;
        /// Path to fragment shader.
        std::filesystem::path fragmentShader;
    } shader_load_from_files_args_t;

    /// Shader program factory.
    /// Creates shared instances of shader programs.
    class ShaderFactory
    {
    public:
        static std::shared_ptr<Shader> loadFromFile(const shader_load_from_files_args_t &args);

    private:
        static GLuint loadShader(const std::filesystem::path &path, const GLenum &type);
    };
}

#endif //RENGINE_SRC_RENDERING_SHADERFACTORY_HPP
