#ifndef RENGINE_SRC_RENDERING_SHADER_HPP
#define RENGINE_SRC_RENDERING_SHADER_HPP

#include <string>

#include <glad/glad.h>
#include <glm/vec2.hpp>
#include <glm/vec3.hpp>
#include <glm/vec4.hpp>
#include <glm/mat2x2.hpp>
#include <glm/mat3x3.hpp>
#include <glm/mat4x4.hpp>

namespace rengine
{
    class ShaderFactory;

    /// Type of shader program.
    /// Stored identity of OpenGL shader program and provides access to shader uniforms.
    class Shader
    {
        friend class ShaderFactory;

    public:
        /// Creates instance of shader.
        explicit Shader();

        /// Destroys instance of shader and deletes OpenGL identity.
        ~Shader();

        /// Uses this shader program.
        void use() const;

        /// Sets value of boolean uniform.
        /// \param name Name of uniform.
        /// \param value Value of uniform.
        void setBool(const std::string &name, const bool &value) const;

        /// Sets value of integer uniform.
        /// \param name Name of uniform.
        /// \param value Value of uniform.
        void setInt(const std::string &name, const int &value) const;

        /// Sets value of float uniform.
        /// \param name Name of uniform.
        /// \param value Value of uniform.
        void setFloat(const std::string &name, const float &value) const;

        /// Sets value of double uniform.
        /// \param name Name of uniform.
        /// \param value Value of uniform.
        void setDouble(const std::string &name, const double &value) const;

        /// Sets value of 2d-vector uniform.
        /// \param name Name of uniform.
        /// \param value Value of uniform.
        void setVec2(const std::string &name, const glm::vec2 &value) const;

        /// Sets value of 3d-vector uniform.
        /// \param name Name of uniform.
        /// \param value Value of uniform.
        void setVec3(const std::string &name, const glm::vec3 &value) const;

        /// Sets value of 4d-vector uniform.
        /// \param name Name of uniform.
        /// \param value Value of uniform.
        void setVec4(const std::string &name, const glm::vec4 &value) const;

        /// Sets value of 2x2 matrix uniform.
        /// \param name Name of uniform.
        /// \param value Value of uniform.
        void setMat2(const std::string &name, const glm::mat2 &value) const;

        /// Sets value of 3x3 matrix uniform.
        /// \param name Name of uniform.
        /// \param value Value of uniform.
        void setMat3(const std::string &name, const glm::mat3 &value) const;

        /// Sets value of 4x4 matrix uniform.
        /// \param name Name of uniform.
        /// \param value Value of uniform.
        void setMat4(const std::string &name, const glm::mat4 &value) const;

    private:
        GLuint _id;

        /// Locates uniform and returns its location.
        /// \param name Name of uniform.
        /// \return Location of uniform.
        [[nodiscard]]
        GLuint locateUniform(const std::string &name) const;
    };
}

#endif //RENGINE_SRC_RENDERING_SHADER_HPP
