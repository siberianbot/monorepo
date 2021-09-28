#include "Shader.hpp"

namespace rengine
{
    Shader::Shader() : _id(0)
    {
        //
    }

    Shader::~Shader()
    {
        glDeleteProgram(_id);
    }

    void Shader::use() const
    {
        glUseProgram(_id);
    }

    void Shader::setBool(const std::string &name, const bool &value) const
    {
        glUniform1i(locateUniform(name), (int) value);
    }

    void Shader::setInt(const std::string &name, const int &value) const
    {
        glUniform1i(locateUniform(name), value);
    }

    void Shader::setFloat(const std::string &name, const float &value) const
    {
        glUniform1f(locateUniform(name), value);
    }

    void Shader::setDouble(const std::string &name, const double &value) const
    {
        glUniform1d(locateUniform(name), value);
    }

    void Shader::setVec2(const std::string &name, const glm::vec2 &value) const
    {
        glUniform2fv(locateUniform(name), 1, &value[0]);
    }

    void Shader::setVec3(const std::string &name, const glm::vec3 &value) const
    {
        glUniform3fv(locateUniform(name), 1, &value[0]);
    }

    void Shader::setVec4(const std::string &name, const glm::vec4 &value) const
    {
        glUniform4fv(locateUniform(name), 1, &value[0]);
    }

    void Shader::setMat2(const std::string &name, const glm::mat2 &value) const
    {
        glUniformMatrix2fv(locateUniform(name), 1, GL_FALSE, &value[0][0]);
    }

    void Shader::setMat3(const std::string &name, const glm::mat3 &value) const
    {
        glUniformMatrix3fv(locateUniform(name), 1, GL_FALSE, &value[0][0]);
    }

    void Shader::setMat4(const std::string &name, const glm::mat4 &value) const
    {
        glUniformMatrix4fv(locateUniform(name), 1, GL_FALSE, &value[0][0]);
    }

    GLuint Shader::locateUniform(const std::string &name) const
    {
        return glGetUniformLocation(_id, name.c_str());
    }
}