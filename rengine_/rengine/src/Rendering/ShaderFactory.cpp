#include "ShaderFactory.hpp"

#include <fstream>
#include <sstream>

#include "../Utils/Assert.hpp"

namespace rengine
{
    std::shared_ptr<Shader> ShaderFactory::loadFromFile(const shader_load_from_files_args_t &args)
    {
        GLuint vertexShader = ShaderFactory::loadShader(args.vertexShader, GL_VERTEX_SHADER);
        GLuint fragmentShader = ShaderFactory::loadShader(args.fragmentShader, GL_FRAGMENT_SHADER);

        GLuint shaderProgramId = glCreateProgram();
        glAttachShader(shaderProgramId, vertexShader);
        glAttachShader(shaderProgramId, fragmentShader);

        glLinkProgram(shaderProgramId);

        // TODO: more detailed log is required.
        // TODO: also there should be some cleanup.
        GLint isLinked = 0;
        glGetProgramiv(shaderProgramId, GL_LINK_STATUS, &isLinked);
        engineAssert(isLinked == GL_TRUE, "Shader Factory", "shader program is not linked");

        glDeleteShader(vertexShader);
        glDeleteShader(fragmentShader);

        std::shared_ptr<Shader> instance = std::make_shared<Shader>();
        instance->_id = shaderProgramId;

        return instance;
    }

    GLuint ShaderFactory::loadShader(const std::filesystem::path &path, const GLenum &type)
    {
        std::ifstream file(path);

        engineAssert(file.is_open(), "Shader Factory", "shader file is not opened");

        std::stringstream sstr;
        sstr << file.rdbuf();
        file.close();

        std::string codeStr = sstr.str();
        const char *code = codeStr.c_str();

        GLuint shaderId = glCreateShader(type);
        glShaderSource(shaderId, 1, &code, nullptr);
        glCompileShader(shaderId);

        // TODO: more detailed log is required.
        // TODO: also there should be some cleanup.
        GLint isCompiled = 0;
        glGetShaderiv(shaderId, GL_COMPILE_STATUS, &isCompiled);
        engineAssert(isCompiled == GL_TRUE, "Shader Factory", "shader file is not compiled");

        return shaderId;
    }
}