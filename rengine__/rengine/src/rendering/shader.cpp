#include "shader.hpp"

#include <fstream>
#include <sstream>

#include "../utils/assert.hpp"

namespace rengine
{
    shader::shader() : _id(0)
    {
        //
    }

    shader::~shader()
    {
        if (_id != 0)
        {
            destroy();
        }
    }

    void shader::use() const
    {
        engineAssert(_id != 0, "Rendering/Shaders: called \".use\", but shader program is not created by OpenGL");

        glUseProgram(_id);
    }

    void shader::destroy()
    {
        glDeleteProgram(_id);

        _id = 0;
    }

    std::shared_ptr<shader> shaderFactory::create(const shader_params_t &shaderParams)
    {
        GLuint vertex = loadShader(shaderParams.vertexShaderPath, GL_VERTEX_SHADER);
        GLuint fragment = loadShader(shaderParams.vertexShaderPath, GL_FRAGMENT_SHADER);

        GLuint program = glCreateProgram();
        glAttachShader(program, vertex);
        glAttachShader(program, fragment);
        glLinkProgram(program);

        GLint status;
        glGetProgramiv(program, GL_LINK_STATUS, &status);

        engineAssert(status == GL_TRUE, "Rendering/ShaderFactory: program linking failed");

        std::shared_ptr<shader> ptr = std::make_shared<shader>();
        ptr->_id = program;

        glDeleteShader(vertex);
        glDeleteShader(fragment);

        return ptr;
    }

    GLuint shaderFactory::loadShader(const std::string &path, const GLenum &type)
    {
        std::ifstream reader(path);
        engineAssert(reader.is_open(), "Rendering/ShaderFactory: target shader file is not opened");

        std::stringstream sstream;
        sstream << reader.rdbuf();

        reader.close();
        std::string content = sstream.str();
        const char *contentCstr = content.c_str();

        GLuint shader = glCreateShader(type);
        glShaderSource(shader, 1, &contentCstr, nullptr);
        glCompileShader(shader);

        GLint status;
        glGetShaderiv(shader, GL_COMPILE_STATUS, &status);

        engineAssert(status == GL_TRUE, "Rendering/ShaderFactory: shader compilation failed");

        return shader;
    }
}