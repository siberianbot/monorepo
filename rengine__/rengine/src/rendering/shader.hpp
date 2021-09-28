#ifndef RENGINE_SRC_RENDERING_SHADER_HPP
#define RENGINE_SRC_RENDERING_SHADER_HPP

#include <memory>
#include <string>

#include <glad/glad.h>

namespace rengine
{
    typedef struct shaderParams
    {
        std::string vertexShaderPath;
        std::string fragmentShaderPath;
    } shader_params_t;

    class shader
    {
    public:
        friend class shaderFactory;

        explicit shader();

        ~shader();

        void use() const;
        void destroy();

    private:
        GLuint _id;

    };

    class shaderFactory
    {
    public:
        static std::shared_ptr<shader> create(const shader_params_t &shaderParams);

    private:
        static GLuint loadShader(const std::string &path, const GLenum &type);
    };
}

#endif //RENGINE_SRC_RENDERING_SHADER_HPP
